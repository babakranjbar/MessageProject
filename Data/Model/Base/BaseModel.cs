namespace Data.Model.Base
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool Deleted { get; set; }

    }
}
