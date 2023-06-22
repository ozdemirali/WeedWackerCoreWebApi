using System.ComponentModel.DataAnnotations;

namespace WeedWackerCoreWebApi.Entity
{
    public class Quarter
    {
        public int Id { get; set; }

        [Required]
        public int PlateCode { get; set; }
        [Required]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

    }
}
