using Microsoft.EntityFrameworkCore;
using WeedWackerCoreWebApi.Context;
using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Repository
{
    public class EmployerOfferRepository : IEmployerOfferRepository,IDisposable
    {
        private WeedWackerDbContext _context;
        private bool disposed = false;

        public EmployerOfferRepository(WeedWackerDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<ViewModelEmployerOffer> GetOffers(string id)
        {
            var data = _context.EmployerOffers.Where(o => o.UserId == id).ToList();

            if (data.Any())
            {
                return data.Select(o => new ViewModelEmployerOffer
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    WorkId = o.WorkId,
                    CustomerId = o.CustomerId,
                    StartTime = o.StartTime,
                    EndTime = o.EndTime,
                    Price = o.Price
                }).ToList();
            }

            return Enumerable.Empty<ViewModelEmployerOffer>();

          
        }

        public void InsertOffer(ViewModelEmployerOffer offer)
        {

            var data = new EmployerOffer
            {
                UserId = offer.UserId,
                WorkId = offer.WorkId,
                CustomerId = offer.CustomerId,
                Price = offer.Price,
                StartTime = offer.StartTime,
                EndTime = offer.EndTime,
                AddedDate = DateTime.Now
            };
            _context.EmployerOffers.Add(data);
        }

        public void UpdateOffer(ViewModelEmployerOffer offer)
        {
            var data = _context.EmployerOffers.Find(offer.Id);
            data.StartTime = offer.StartTime;
            data.EndTime = offer.EndTime;
            data.Price = offer.Price;
            data.ModifiedDate=DateTime.Now;

            _context.Entry(data).State = EntityState.Modified;
        }

        public void DeleteOffer(Int64 id)
        {
            var data = _context.EmployerOffers.Find(id);
            _context.EmployerOffers.Remove(data);
        }

        public int Save()
        {
            return _context.SaveChanges();
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
