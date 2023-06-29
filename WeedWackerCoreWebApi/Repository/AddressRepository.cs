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
            var data = _context.Addresses.Find(id);
            _context.Addresses.Remove(data);
        }


        public IEnumerable<ViewModelAddress> GetAddress()
        {
            return _context.Addresses.Select(a => new ViewModelAddress
            {
                Id=a.Id,
                PlateCode=a.PlateCode,
                CountryId=a.CountryId,  
                AddInfo=a.AddInfo,
                PostCode=a.PostCode,
                Phone= a.Phone , 
            }).ToList();
        }

        public ViewModelAddress GetAdressById(string id)
        {
            var data = _context.Addresses.Where(a => a.Id == id).Select(a => new ViewModelAddress
            {
                Id=a.Id,
                PlateCode=a.PlateCode,
                CountryId=a.CountryId,
                AddInfo=a.AddInfo,
                PostCode = a.PostCode,
                Phone =a.Phone,
                
            }).FirstOrDefault();

            return data;
        }

        public void InsertAddress(ViewModelAddress address)
        {
            var data = new Address
            {
                Id=address.Id,
                UserId=address.Id,
                PlateCode = address.PlateCode,
                CountryId = address.CountryId,
                PostCode = address.PostCode,
                Phone = address.Phone,
                AddInfo = address.AddInfo,
                AddedDate=DateTime.Now,
            };
            _context.Addresses.Add(data);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void UpdateAddress(ViewModelAddress address)
        {
            var data = _context.Addresses.Find(address.Id);
            data.AddInfo=address.AddInfo;
            data.CountryId=address.CountryId;
            data.Phone= address.Phone;
            data.PlateCode = address.PlateCode;
            data.Phone = data.Phone;
            data.ModifiedDate= DateTime.Now;
            _context.Entry(data).State = EntityState.Modified;
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
