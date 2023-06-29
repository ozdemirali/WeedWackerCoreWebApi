using System.ComponentModel.DataAnnotations;

namespace WeedWackerCoreWebApi.ViewModel
{
    public class ViewModelAddress
    {
        public string? Id { get; set; }
        public int PlateCode { get; set; }
        public int CountryId { get; set; }
        public string? PostCode { get; set; }
        public string? AddInfo { get; set; }
        public string? Phone { get; set; }
    }
}
