using System.ComponentModel.DataAnnotations;

namespace WeedWackerCoreWebApi.Entity
{
    public class City
    {
        [Key]
        [Required]
        public int PlateCode { get; set; }
        
        [MaxLength(50)]
        public string? Name;
    }
}
