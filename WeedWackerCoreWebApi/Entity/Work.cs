using System.ComponentModel.DataAnnotations;

namespace WeedWackerCoreWebApi.Entity
{
    public class Work:BaseEntity
    {
        [Required]
        public Int64 ProvinceId { get; set; }
        [Required]
        public Int64 DistrictId { get; set;}

        [MaxLength(255)]    
        public string? Description { get; set; }


        public string? UserId { get; set; }
        public User? User { get; set; }  


        public ICollection<EmployerOffer>? EmployerOffers { get; set; } 
    }
}
