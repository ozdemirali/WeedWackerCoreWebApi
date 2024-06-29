using System.ComponentModel.DataAnnotations;

namespace WeedWackerCoreWebApi.Entity
{
    public class Address:BaseEmailEntity
    {
        [Required]
        public int PlateCode { get; set; }
        
        [Required]
        public int DistrictId { get; set; }
        public string? PostCode { get; set; }

        [MaxLength(50)]
        public string? AddInfo { get; set; }
        public string? Phone { get; set; }

        public string? UserId { get; set; }
        public User? User { get; set; }


    }
}
