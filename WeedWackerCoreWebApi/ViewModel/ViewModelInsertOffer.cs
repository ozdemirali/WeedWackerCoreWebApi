namespace WeedWackerCoreWebApi.ViewModel
{
    public class ViewModelInsertOffer
    {
        public string? UserId { get; set; }
        public Int64 WorkId { get; set; }
        public double Price { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
