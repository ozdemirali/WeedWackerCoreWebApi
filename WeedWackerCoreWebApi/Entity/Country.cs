using System.ComponentModel.DataAnnotations;

namespace WeedWackerCoreWebApi.Entity
{
    public class Country
    {
        
        public int Id { get; set; }
        
        [Required]
        public Int64 ProvinceId { get; set; }
       
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }   
    }
}
