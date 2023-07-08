using WeedWackerCoreWebApi.Context;
using WeedWackerCoreWebApi.Entity;
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
            try
            {
                var data = (from u in _context.Users
                            join r in _context.Roles
                            on u.RoleId equals r.Id
                            where u.Id == user.Email && u.Password == user.Password
                            select new CurrentUser
                            {
                                Email = u.Id,
                                Name = u.Name,
                                Role = r.Name
                            }).FirstOrDefault();


                return data;
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "User Repository - ControlUser(ViewModelUser user)",
                };
                _context.Errors.Add(error);
                return new CurrentUser();
            }
           
        }

        protected virtual void Dispose(bool disposing)
        {
            try
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
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "User Repository - Dispose(bool disposing)",
                };
                _context.Errors.Add(error);
            }

            
        }

        public void Dispose()
        {
            try
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            catch (Exception e) 
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "User Repository - Dispose()",
                };
                _context.Errors.Add(error);
            }
        }
    }
}
