using Data.Model.Message;
using System.Linq;

namespace Data.Mapper
{
    public static class MessageMapper
    {
        public static Message ToDataModel(this MessageSaveModel model)
        {
            return new Message
            {
                Body= model.Body,
                ChatId= model.ChatId,
                CreateDate= model.CreateDate,
                ForwardFrom= model.ForwardFrom,
                Deleted= model.Deleted,
                EdditDate= model.EdditDate,
                Id= model.Id,   
                ParentId= model.ParentId,
                SenderNumber = model.SenderNumber,
            };
        }

        public static MesageViewModel ToViewModel(this Message message)
        {
            return new MesageViewModel
            {
                Body = message.Body,
                ParentId = message.ParentId,
                ChatId = message.ChatId,
                Forward = message.ForwardFrom,
                Id = message.Id,
            };
        }

 
    }
}
