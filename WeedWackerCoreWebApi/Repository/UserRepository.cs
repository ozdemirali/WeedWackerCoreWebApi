using WeedWackerCoreWebApi.Context;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.Model;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Repository
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private WeedWackerDbContext _context;
        private bool disposed = false;

        public UserRepository(WeedWackerDbContext context)
        {
            this._context = context;
        }

        public CurrentUser ControlUser(ViewModelUser user)
        {
            var data = (from u in _context.Users
                        join r in _context.Roles
                        on u.RoleId equals r.Id
                        where u.Id == user.Email && u.Password == user.Password
                        select new CurrentUser
                        {
                            Email=u.Id,
                            Role=r.Name
                        }).FirstOrDefault();


            return data;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
