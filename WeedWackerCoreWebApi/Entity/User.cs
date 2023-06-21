using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeedWackerCoreWebApi.Entity
{
    public class User:BaseEmailEntity
    {

        
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string? Password { get; set; }
       

        public Address? Address { get; set; }
        public EmployerSetting? EmployerSetting { get; set; }    

        public byte RoleId { get; set; }  
        public Role? Role { get; set; }  

        public ICollection<Work>? Works { get; set; }
        public ICollection<EmployerOffer>? EmployerOffers { get; set; }


    }
}
