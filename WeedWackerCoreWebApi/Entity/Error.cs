namespace WeedWackerCoreWebApi.Entity
{
    public class Error
    {
        public Guid Id { get; set; }
        public string? Message { get; set; } 
        public string? Place { get; set; }
        public DateTime Time { get; set; }
        public Error() { 
         this.Time = DateTime.UtcNow;
        }  
    }
}
