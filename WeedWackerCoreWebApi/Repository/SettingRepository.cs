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
            var data = _context.EmployerSetting.Find(id);
            _context.EmployerSetting.Remove(data);
        }

      

        public ViewModelSetting GetSettingById(string id)
        {
            var data = _context.EmployerSetting.Where(s => s.Id == id).Select(s => new ViewModelSetting
            {
                Id=s.Id,
                PlateCode=s.PlateCode,
                CountryId=s.CountryId,
            }).FirstOrDefault();

            return data;
        }

        public IEnumerable<ViewModelSetting> GetSettings()
        {
            return _context.EmployerSetting.Select(s=> new ViewModelSetting {
               Id=s.Id,
               PlateCode=s.PlateCode,
               CountryId=s.CountryId,

            }).ToList();
        }

        public void InsertStting(ViewModelSetting setting)
        {
            var data = new EmployerSetting
            {
                Id=setting.Id,
                PlateCode=setting.PlateCode,
                CountryId=setting.CountryId,
                UserId=setting.Id,
                AddedDate=DateTime.Now,
            };

            _context.EmployerSetting.Add(data);
           
        }

        public int Save()
        {
           return _context.SaveChanges() ;
        }

        public void UpdateSetting(ViewModelSetting setting)
        {
            var data = _context.EmployerSetting.Find(setting.Id);
            data.PlateCode = setting.PlateCode;
            data.CountryId = setting.CountryId;
            data.ModifiedDate = DateTime.Now;

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
