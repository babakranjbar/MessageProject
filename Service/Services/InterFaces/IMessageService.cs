using Data.Model.Message;

namespace Service.Services.InterFaces
{
    public interface IMessageService
    {
        void Save(MessageSaveModel message);
        void Forward(ForwardMessage message);
        IEnumerable<MesageViewModel> GetByChatID(Guid id);
        void DelateRange(Guid chatId);


    }
}
