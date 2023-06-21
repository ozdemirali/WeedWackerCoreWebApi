using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WeedWackerCoreWebApi.Entity
{
    public class BaseEntity
    {
        public Int64 Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime Modified { get; set; }

    }
}
