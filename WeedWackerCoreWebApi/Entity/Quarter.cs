using System.ComponentModel.DataAnnotations;

namespace WeedWackerCoreWebApi.Entity
{
    public class Quarter
    {
        public int Id { get; set; }

        [Required]
        public Int64 CityId { get; set; }
        [Required]
        public Int64 CountryId { get; set; }
        
    }
}
