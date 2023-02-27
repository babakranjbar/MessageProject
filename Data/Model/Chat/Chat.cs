using Data.Model.Base;

namespace Data.Model.Chat
{
    public class Chat : BaseModel
    {
        public string ChatName { get; set; }



        public virtual IEnumerable<Message.Message> Messages { get; set; }
    }
}
