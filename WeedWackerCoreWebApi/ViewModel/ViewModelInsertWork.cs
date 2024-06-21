namespace WeedWackerCoreWebApi.ViewModel
{
    public class ViewModelInsertWork
    {
        public int PlateCode { get; set; }
        public int DistrictId { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? UserId { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
