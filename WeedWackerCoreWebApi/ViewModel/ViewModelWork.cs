using System.ComponentModel.DataAnnotations;
using WeedWackerCoreWebApi.Entity;

namespace WeedWackerCoreWebApi.ViewModel
{
    public class ViewModelWork
    {
        public Int64 Id { get; set; }
        public int PlateCode { get; set; }
        [Required]
        public int CountryId { get; set; }
        public string? Description { get; set; }
        public string? UserId { get; set; }
        
    }
}
