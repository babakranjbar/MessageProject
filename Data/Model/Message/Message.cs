using Data.Model.Base;

namespace Data.Model.Message
{
    public class Message : BaseModel
    {
        public Guid? ParentId { get; set; }
        public Guid? ChatId { get; set; }
        public Guid? ForwardFrom { get; set; }
        public DateTime? EdditDate { get; set; }
        public string SenderNumber { get; set; }
        public string Body { get; set; }




        public virtual Chat.Chat Chat { get; set; }
        public virtual Message message { get; set; }

    }
}
