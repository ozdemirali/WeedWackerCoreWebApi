using Microsoft.Identity.Client;
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
            try
            {
                _context.Errors.Add(error);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error Repository InsertError(Error error)");
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

                throw new Exception("Error Repository Dispose(bool disposing)");
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
                throw new Exception("Error Repository Dispose()");
            }
           
        }
    }
}
