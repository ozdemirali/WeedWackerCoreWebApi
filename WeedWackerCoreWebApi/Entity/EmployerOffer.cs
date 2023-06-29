namespace WeedWackerCoreWebApi.Entity
{
    public class EmployerOffer:BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public double Price { get; set; }

        public string? UserId { get; set; }
        public User? User { get; set; }

        public Int64 WorkId { get; set; }
        public Work? Work { get; set; }
    }
}
