using Data.Model.Chat;

namespace Service.Services.InterFaces
{
    public interface IChatService
    {
        IEnumerable<Chat> GetChats();
        Guid Insert(string chatName = "NewChat");
        void Update(Chat chat);
        void Delete(Guid id);
    }
}
