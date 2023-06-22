using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeedWackerCoreWebApi.Entity
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int PlateCode { get; set; }
        
        [MaxLength(50)]
        public string? Name { get; set; }
    }
}
