namespace WeedWackerCoreWebApi.Entity
{
    public class EmployerSetting:BaseEmailEntity
    {
        public int PlateCode { get; set; }
        public int CountryId { get; set; }

        public string? UserId { get; set; }
        public User? User { get; set; }

    }
}
