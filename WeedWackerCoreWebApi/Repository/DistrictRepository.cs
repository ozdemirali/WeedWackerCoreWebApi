using Microsoft.EntityFrameworkCore;
using WeedWackerCoreWebApi.Context;
using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Repository
{
    public class DistrictRepository: IDistrictRepository,IDisposable
    {
        private WeedWackerDbContext _context;
        private bool disposed = false;
        public DistrictRepository(WeedWackerDbContext context)
        {
            this._context = context;
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
                    Place = "District Repository -  Dispose()",
                };
                _context.Errors.Add(error);
            }


        }

        public IEnumerable<ViewModelDistrict> GetDistrictsById(int plateCode)
        {
            var result = (from d in _context.Districts
                         where d.PlateCode == plateCode
                         select new ViewModelDistrict
                         {
                             Id=d.Id,
                             Name = d.Name
                         }).ToList();
            return result;
                    
        }

        public int Save()
        {
            throw new NotImplementedException();
        }
    }
}
