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
            try
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
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "EmployerOffer Repository - GetOffers(string id)",
                };

                _context.Errors.Add(error);
                return Enumerable.Empty<ViewModelEmployerOffer>();
            }
        }

        public void InsertOffer(ViewModelEmployerOffer offer)
        {
            try
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
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "EmployerOffer Repository - InsertOffer(ViewModelEmployerOffer offer)",
                };
                _context.Errors.Add(error); 

            }

            

        }

        public void UpdateOffer(ViewModelEmployerOffer offer)
        {
            try
            {
                var data = _context.EmployerOffers.Find(offer.Id);
                data.StartTime = offer.StartTime;
                data.EndTime = offer.EndTime;
                data.Price = offer.Price;
                data.ModifiedDate = DateTime.Now;

                _context.Entry(data).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "EmployerOffer Repository - UpdateOffer(ViewModelEmployerOffer offer)",
                };
                _context.Errors.Add(error);
            }
           
        }

        public void DeleteOffer(Int64 id)
        {
            try
            {
                var data = _context.EmployerOffers.Find(id);
                _context.EmployerOffers.Remove(data);
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "EmployerOffer Repository - DeleteOffer(Int64 id)",
                };
                _context.Errors.Add(error);
            }
            
        }

        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "EmployerOffer Repository - Save()",
                };
                _context.Errors.Add(error);
                return 0;
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
                    Place = "EmployerOffer Repository - Dispose(bool disposing)",
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
                    Place = "EmployerOffer Repository - Dispose()",
                };
                _context.Errors.Add(error);
            }
           
        }

       
    }
}
