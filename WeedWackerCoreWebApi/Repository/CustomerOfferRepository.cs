using Microsoft.EntityFrameworkCore;
using WeedWackerCoreWebApi.Context;
using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Repository
{
    public class CustomerOfferRepository : ICustomerOfferRepository, IDisposable
    {
        private WeedWackerDbContext _context;
        private bool disposed = false;
        public CustomerOfferRepository(WeedWackerDbContext context)
        {
            this._context = context;
        }


        public IEnumerable<ViewModelCustomerOffer> GetOffers(string id)
        {
            var data = _context.EmployerOffers.Where(o => o.CustomerId == id).ToList();
            if (data.Any())
            {
                var result = data.Select(o => new ViewModelCustomerOffer
                {
                    User = o.UserId,
                    StartTime = o.StartTime,
                    EndTime = o.EndTime,
                    Price = o.Price,
                    Phone = _context.Addresses.Find(o.UserId).Phone,
                }).ToList();

                return result;
            }
            return Enumerable.Empty<ViewModelCustomerOffer>();
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
