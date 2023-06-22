using System.ComponentModel.DataAnnotations.Schema;

namespace WeedWackerCoreWebApi.Entity
{
    public class Role
    {
        public byte Id { get; set; }
        public string? Name { get; set; }    

        public ICollection<User>? Users { get; set; }
    }
}
