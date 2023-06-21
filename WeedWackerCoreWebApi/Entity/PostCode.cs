using System.ComponentModel.DataAnnotations;

namespace WeedWackerCoreWebApi.Entity
{
    public class PostCode
    {
        [Key]
        [Required]
        public string? Code { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public int QuarterId { get; set; }
    }
}
