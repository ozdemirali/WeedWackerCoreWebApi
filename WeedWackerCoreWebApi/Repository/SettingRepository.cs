using Microsoft.EntityFrameworkCore;
using WeedWackerCoreWebApi.Context;
using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Repository
{
    public class SettingRepository : ISettingRepository, IDisposable
    {
        private WeedWackerDbContext _context;
        private bool disposed = false;

        public SettingRepository(WeedWackerDbContext context)
        {
            this._context = context;
        }
        public void DeleteSetting(string id)
        {
            try
            {
                var data = _context.EmployerSetting.Find(id);
                _context.EmployerSetting.Remove(data);
            }
            catch (Exception e)
            {

                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Setting Repository - DeleteSetting(string id)",
                };
                _context.Errors.Add(error);
            }

           
        }

      

        public ViewModelSetting GetSettingById(string id)
        {
            try
            {
                var data = _context.EmployerSetting.Where(s => s.Id == id).Select(s => new ViewModelSetting
                {
                    Id = s.Id,
                    PlateCode = s.PlateCode,
                    CountryId = s.CountryId,
                }).FirstOrDefault();

                return data;
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Setting Repository - DGetSettingById(string id)",
                };
                _context.Errors.Add(error);

                return new ViewModelSetting();
            }

            
        }

        public IEnumerable<ViewModelSetting> GetSettings()
        {
            try
            {
                return _context.EmployerSetting.Select(s => new ViewModelSetting
                {
                    Id = s.Id,
                    PlateCode = s.PlateCode,
                    CountryId = s.CountryId,

                }).ToList();
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Setting Repository - GetSettings()",
                };
                _context.Errors.Add(error);

                return Enumerable.Empty<ViewModelSetting>();

            }
        }

        public void InsertStting(ViewModelSetting setting)
        {
            try
            {
                var data = new EmployerSetting
                {
                    Id = setting.Id,
                    PlateCode = setting.PlateCode,
                    CountryId = setting.CountryId,
                    UserId = setting.Id,
                    AddedDate = DateTime.Now,
                };

                _context.EmployerSetting.Add(data);
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Setting Repository - InsertStting(ViewModelSetting setting)",
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
                    Place = "Setting Repository - Save()",
                };
                _context.Errors.Add(error);
                return 0;

            }

           
        }

        public void UpdateSetting(ViewModelSetting setting)
        {
            try
            {
                var data = _context.EmployerSetting.Find(setting.Id);
                data.PlateCode = setting.PlateCode;
                data.CountryId = setting.CountryId;
                data.ModifiedDate = DateTime.Now;

                _context.Entry(data).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Setting Repository - UpdateSetting(ViewModelSetting setting)",
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
                    Place = "Setting Repository - Dispose(bool disposing)",
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
                    Place = "Setting Repository - Dispose(bool disposing)",
                };
                _context.Errors.Add(error);
            }
            
        }
    }
}
