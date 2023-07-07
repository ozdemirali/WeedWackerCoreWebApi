using WeedWackerCoreWebApi.Context;
using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.IRepository;

namespace WeedWackerCoreWebApi.Repository
{
    public class ErrorRepository : IErrorRepository, IDisposable
    {

        private WeedWackerDbContext _context;
        private bool disposed = false;

        public ErrorRepository(WeedWackerDbContext context)
        {
            this._context = context;
        }

        public void InsertError(Error error)
        {
            _context.Errors.Add(error);
            _context.SaveChanges();
           
          
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
