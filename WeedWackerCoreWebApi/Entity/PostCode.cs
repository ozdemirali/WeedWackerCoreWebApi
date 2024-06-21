using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeedWackerCoreWebApi.Entity
{
    public class PostCode
    {
        public int Id { get; set; } 
       
        [Required]
        public int PlateCode { get; set; }
        [Required]
        public int DistrictId { get; set; }
        [Required]
        public int QuarterId { get; set; }
        [Required]
        public string? Code { get; set; }
    }
}
