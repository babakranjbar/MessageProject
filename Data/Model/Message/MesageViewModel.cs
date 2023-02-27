
namespace Data.Model.Message
{
    public class MesageViewModel
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? ChatId { get; set; }
        public Guid? Forward { get; set; }
        public string Body { get; set; }
        public IEnumerable<MesageViewModel>? ChaildMessage { get; set; }
    }
}
