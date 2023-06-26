namespace WeedWackerCoreWebApi.ViewModel
{
    public class ViewModelUpdateWork
    {
        public Int64 Id { get; set; }   
        public int PlateCode { get; set; }
        public int CountryId { get; set; }
        public string? Description { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
