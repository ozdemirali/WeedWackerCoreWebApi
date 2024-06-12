using Microsoft.EntityFrameworkCore;
using WeedWackerCoreWebApi.Context;
using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Repository
{
    public class CityRepository : ICityRepository, IDisposable
    {
        private WeedWackerDbContext _context;
        private bool disposed = false;

        public CityRepository(WeedWackerDbContext context)
        {
            this._context = context;
        }
        public void DeleteCity(int plateCode)
        {
            try
            {
                var data = _context.Cities.Find(plateCode);
                _context.Cities.Remove(data);   
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "City Repository - DeleteCity(int plateCode)"
                };
                _context.Errors.Add(error);
                _context.SaveChanges();
            }
        }

        public IEnumerable<City> GetCities()
        {
            try
            {
                return _context.Cities.ToList();
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "City Repository - GetCities()",
                };
                _context.Errors.Add(error);
                _context.SaveChanges();
                return Enumerable.Empty<City>();    
            }

        }

        public City GetCityById(int plateCode)
        {
            try
            {
                return _context.Cities.Where(p => p.PlateCode == plateCode).FirstOrDefault();
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "City Repository - GetCityById(int plateCode)",
                };
                _context.Errors.Add(error);
                _context.SaveChanges();
                return new City();
            }
        }

        public void InsertCity(City city)
        {
            try
            {
                _context.Cities.Add(city);
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "City Repository - InsertCity(City city)",
                };
                _context.Errors.Add(error);
                _context.SaveChanges(); 
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
                    Place = "City Repository - Save()",
                };
                _context.Errors.Add(error);
                return 0;
            }
        }

        public void UpdateCity(City city)
        {
            try
            {
                var data = _context.Cities.Where(p => p.PlateCode == city.PlateCode).FirstOrDefault();
                data.Name=city.Name;
                _context.Entry(data).State=EntityState.Modified;

            }
            catch (Exception e)
            {

                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "City Repository - UpdateCity(City city)",
                };
                _context.Errors.Add(error);
                _context.SaveChanges() ;
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
