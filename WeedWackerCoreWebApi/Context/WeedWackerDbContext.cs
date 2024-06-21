using Microsoft.EntityFrameworkCore;
using WeedWackerCoreWebApi.Entity;

namespace WeedWackerCoreWebApi.Context
{
    public class WeedWackerDbContext:DbContext
    {
        public WeedWackerDbContext(DbContextOptions<WeedWackerDbContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<EmployerOffer> EmployerOffers { get; set; }
        public DbSet<EmployerSetting> EmployerSetting { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<PostCode> PostCodes { get; set; }
        public DbSet<Quarter> Quarter { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Work> Works { get; set; }


    }
}
