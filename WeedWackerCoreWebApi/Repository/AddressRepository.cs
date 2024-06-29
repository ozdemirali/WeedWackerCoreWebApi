using Microsoft.EntityFrameworkCore;
using WeedWackerCoreWebApi.Context;
using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Repository
{
    public class AddressRepository : IAddressRepository, IDisposable
    {

        private WeedWackerDbContext _context;
        private bool disposed = false;

        public AddressRepository(WeedWackerDbContext context)
        {
            this._context = context;
        }
        public void DeleteAddress(string id)
        {
            try
            {
                var data = _context.Addresses.Find(id);
                _context.Addresses.Remove(data);
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Address Repository - DeleteAddress(string id)",
                };
                _context.Errors.Add(error);
            }

           
        }


        public IEnumerable<ViewModelAddress> GetAddress()
        {
            try
            {
                return _context.Addresses.Select(a => new ViewModelAddress
                {
                    Id = a.Id,
                    PlateCode = a.PlateCode,
                    DistrictId = a.DistrictId,
                    AddInfo = a.AddInfo,
                    PostCode = a.PostCode,
                    Phone = a.Phone,
                }).ToList();
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Address Repository - GetAddress()",
                };
                _context.Errors.Add(error);
                
                return Enumerable.Empty<ViewModelAddress>();
            }
            
        }

        public ViewModelAddress GetAdressById(string id)
        {

            try
            {
                var data = _context.Addresses.Where(a => a.Id == id).Select(a => new ViewModelAddress
                {
                    Id = a.Id,
                    PlateCode = a.PlateCode,
                    DistrictId = a.DistrictId,
                    AddInfo = a.AddInfo,
                    PostCode = a.PostCode,
                    Phone = a.Phone,

                }).FirstOrDefault();

                return data;
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Address Repository - GetAddressById()",
                };
                _context.Errors.Add(error);
                return new ViewModelAddress();
            }
           
        }

        public void InsertAddress(ViewModelAddress address)
        {
            try
            {
                var data = new Address
                {
                    Id = address.Id,
                    UserId = address.Id,
                    PlateCode = address.PlateCode,
                    DistrictId = address.DistrictId,
                    PostCode = address.PostCode,
                    Phone = address.Phone,
                    AddInfo = address.AddInfo,
                    AddedDate = DateTime.Now,
                };
                _context.Addresses.Add(data);
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Address Repository - InsertAddress(ViewModelAddress address)",
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
                    Place = "Address Repository - InsertAddress(ViewModelAddress address)",
                };
                _context.Errors.Add(error);

                return 0;
            }

        }

        public void UpdateAddress(ViewModelAddress address)
        {
            try
            {
                var data = _context.Addresses.Find(address.Id);
                data.AddInfo = address.AddInfo;
                data.DistrictId = address.DistrictId;
                data.Phone = address.Phone;
                data.PlateCode = address.PlateCode;
                data.Phone = data.Phone;
                data.ModifiedDate = DateTime.Now;
                _context.Entry(data).State = EntityState.Modified;
            }
            catch (Exception e)
            {

                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Address Repository - UpdateAddress(ViewModelAddress address)",
                };
                _context.Errors.Add(error);
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
                    Place = "Address Repository -  Dispose(bool disposing)",
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
                    Place = "Address Repository -  Dispose()",
                };
                _context.Errors.Add(error);
            }

           
        }

       
    }
}
