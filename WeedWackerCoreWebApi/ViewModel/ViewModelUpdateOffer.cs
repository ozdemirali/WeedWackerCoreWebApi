namespace WeedWackerCoreWebApi.ViewModel
{
    public class ViewModelUpdateOffer
    {
        public Int64 Id { get; set; }
        public string? UserId { get; set; }
        public Int64 WorkId { get; set; }
        public double Price { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
