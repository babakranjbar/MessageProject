using Data.Context;
using Data.Enums;
using Data.Model.Chat;
using Microsoft.EntityFrameworkCore;
using Service.Services.Factory;
using Service.Services.InterFaces;

namespace Service.Services.Implimentes
{
    public class ChatService : IChatService
    {

        #region Constructor
        private readonly MesaggeContext Context;
        private readonly IServiceFactory Service = new ServiceFactory();

        public ChatService(MesaggeContext context)
        {
            this.Context = context;
        }

        #endregion

        public void Delete(Guid id)
        {
            var model = Context.Chat.First(c => c.Id == id);
            Update(ApplyChange(model, ObjectState.Delete));
            Service.CreateMessage(Context).DelateRange(id);
        }
        public Guid Insert(string chatName = "NewChat")
        {
            var model = new Chat
            {
                ChatName = chatName,
            };
            Context.Chat.Add(ApplyChange(model, ObjectState.Add));
            Context.SaveChanges();
            return model.Id;
        }
        public void Update(Chat chat)
        {
            Context.Chat.Update(ApplyChange(chat, ObjectState.Update));
            Context.SaveChanges();
        }
        private static Chat ApplyChange(Chat chat, ObjectState state)
        {
            switch (state)
            {
                case ObjectState.Add:
                    chat.Id = Guid.NewGuid();
                    chat.CreateDate = DateTime.Now;
                    chat.Deleted = false;
                    break;
                case ObjectState.Update:
                    break;
                case ObjectState.Delete:
                    chat.Deleted = true;
                    break;
            }
            return chat;
        }

        public IEnumerable<Chat> GetChats()
        {
            var result = Context.Chat.Select(c => c).ToList();
            


            return result.ToList();
        }
    }
}
