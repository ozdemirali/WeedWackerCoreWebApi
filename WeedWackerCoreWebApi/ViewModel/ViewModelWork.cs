using System.ComponentModel.DataAnnotations;
using WeedWackerCoreWebApi.Entity;

namespace WeedWackerCoreWebApi.ViewModel
{
    public class ViewModelWork
    {
        public Int64 Id { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Description { get; set; }
        public string? User { get; set; }
        
    }
}
