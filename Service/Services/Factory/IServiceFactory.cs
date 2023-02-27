using Data.Context;
using Service.Services.InterFaces;

namespace Service.Services.Factory
{
    public interface IServiceFactory
    {
        IMessageService CreateMessage(MesaggeContext context);
        IChatService CreateChat(MesaggeContext context);
    }
}
