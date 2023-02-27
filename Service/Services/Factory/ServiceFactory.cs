
using Data.Context;
using Service.Services.Implimentes;
using Service.Services.InterFaces;

namespace Service.Services.Factory
{
    public class ServiceFactory : IServiceFactory
    {
        private IMessageService _messageService;
        private IChatService _ChatService;

        public ServiceFactory()
        {

        }

        public IChatService CreateChat(MesaggeContext context)
        {
            if (_ChatService == null)
            {
                _ChatService = new ChatService(context);
            }
            return _ChatService;
        }
        public IMessageService CreateMessage(MesaggeContext context)
        {
            if (_messageService == null)
            {
                _messageService = new MessageService(context);
            }
            return _messageService;
        }
    }
}
