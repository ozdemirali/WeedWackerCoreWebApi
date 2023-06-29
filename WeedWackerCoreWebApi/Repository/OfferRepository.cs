using Microsoft.EntityFrameworkCore;
using WeedWackerCoreWebApi.Context;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Repository
{
    public class OfferRepository : IOfferRepository, IDisposable
    {
        private WeedWackerDbContext _context;
        private bool disposed = false;

        public OfferRepository(WeedWackerDbContext context)
        {
            this._context= context;
        }

        public IEnumerable<ViewModelOffer> GetOffers(Int64 workId)
        {
            var data= _context.EmployerOffers.Where(o => o.WorkId == workId).ToList();
            if (data.Any())
            {
                var result=data.Select(o=> new ViewModelOffer
                {
                    User=o.UserId,
                    StartTime=o.StartTime,
                    EndTime=o.EndTime,
                    Price=o.Price,
                    Phone=_context.Addresses.Find(o.UserId).Phone,
                }).ToList();

                return result;
            }
            return Enumerable.Empty<ViewModelOffer>();


          
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
