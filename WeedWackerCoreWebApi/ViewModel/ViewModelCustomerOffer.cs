namespace WeedWackerCoreWebApi.ViewModel
{
    public class ViewModelCustomerOffer
    {
        public string? User { get; set; }
        public string? Phone { get; set; }
        public double Price { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
