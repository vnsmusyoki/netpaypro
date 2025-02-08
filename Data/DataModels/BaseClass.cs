namespace netpaypro.Data.DataModels
{
    public class BaseClass
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTimeOffset LastUpdatedAt { get; set; } = DateTimeOffset.UtcNow;

        public DateTime? DeletedAt { get; set; }
    }
}
