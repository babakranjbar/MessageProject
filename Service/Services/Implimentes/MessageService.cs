using Data.Context;
using Data.Enums;
using Data.Mapper;
using Data.Model.Message;
using Service.Services.Factory;
using Service.Services.InterFaces;

namespace Service.Services.Implimentes
{
    public class MessageService : IMessageService
    {

        #region Constructor

        private readonly MesaggeContext Context;
        private readonly IServiceFactory Service = new ServiceFactory();
        public MessageService(MesaggeContext context)
        {
            this.Context = context;

        }

        #endregion

        public void DelateRange(Guid chatId)
        {
            var messages = Context.Message.Where(m => m.ChatId == chatId).ToList();
            foreach (var message in messages)
            {
                Delete(message);
            }
            Context.SaveChanges();
        }
        public IEnumerable<MesageViewModel> GetByChatID(Guid id)
        {
            var messages = Context.Message.Where(m => m.ChatId == id).ToList();
            var result = new List<MesageViewModel>();
            foreach (var message in messages)
            {
                result.AddRange(GetChildren(messages, message.Id));
            }
            return result;
        }
        public void Save(MessageSaveModel model)
        {
            var message = model.ToDataModel();
            if (model.State == ObjectState.Add)
                Insert(message);
            else if (model.State == ObjectState.Update)
                Update(message);
            else
                Delete(message);
        }
        private void Delete(Message message)
        {

            Update(ApplyChange(message, ObjectState.Delete));
        }
        private void Insert(Message message)
        {
            Context.Message.Add(ApplyChange(message, ObjectState.Add));
            Context.SaveChanges();
        }
        private void Update(Message message)
        {

            Context.Message.Add(ApplyChange(message, ObjectState.Update));
            Context.SaveChanges();
        }

        private List<MesageViewModel> GetChildren(List<Message> comments, Guid parentId)
        {
            return comments
                    .Where(c => c.ParentId == parentId)
                    .Select(c => new MesageViewModel
                    {
                        Id = c.Id,
                        ParentId = c.ParentId,
                        Body = c.Body,
                        ChatId = c.ChatId,
                        Forward = c.ForwardFrom,
                        ChaildMessage = GetChildren(comments, c.Id),
                    })
                    .ToList();
        }
        private Message ApplyChange(Message message, ObjectState state)
        {
            switch (state)
            {
                case ObjectState.Add:
                    message.Id = Guid.NewGuid();
                    message.CreateDate = DateTime.Now;
                    message.ChatId = GeneriteChatId(message.ChatId);
                    if (message.ParentId == Guid.Empty)
                        message.ParentId = message.Id;
                    break;
                case ObjectState.Update:
                    message.Id = message.ForwardFrom.HasValue ? Guid.NewGuid() : message.Id;
                    message.ChatId = GeneriteChatId(message.ChatId);
                    message.EdditDate = DateTime.Now;
                    break;
                case ObjectState.Delete:
                    message.Deleted = true;
                    break;
            }
            return message;
        }
        private Guid? GeneriteChatId(Guid? chatId)
        {
            return chatId == Guid.Empty ? Service.CreateChat(Context).Insert() : chatId;
        }

        public void Forward(ForwardMessage model)
        {
            var message = model.Message;
            message.ChatId = model.ChatId;
            message.ParentId = message.Id;
            Insert(ApplyChange(message,ObjectState.Add));
        }
    }

}
