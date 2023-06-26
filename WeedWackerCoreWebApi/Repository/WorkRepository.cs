using WeedWackerCoreWebApi.Context;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.ViewModel;
using WeedWackerCoreWebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace WeedWackerCoreWebApi.Repository
{
    public class WorkRepository : IWorkRepository,IDisposable
    {
        private WeedWackerDbContext _context;
        private bool disposed = false;

        public WorkRepository(WeedWackerDbContext contex) {
        this._context = contex; 
        }

        public void DeleteWork(long id)
        {
            var data = _context.Works.Find(id);
            _context.Works.Remove(data);
        }

        

        public IEnumerable<ViewModelWork> GetWorkAll()
        {
            var data = _context.Works.Select(w => new ViewModelWork
            {
                Id = w.Id,
                City = _context.Cities.Where(c => c.PlateCode == w.PlateCode).FirstOrDefault().Name,
                Country=_context.Countries.Where(c=>c.Id==w.CountryId).FirstOrDefault().Name,
                Description = w.Description,
                User = w.UserId
            }).ToList();
           
            return data;
        }

        public ViewModelWork GetWorkById(long id)
        {
            var data= _context.Works.Where(w=>w.Id==id).Select(w=> new ViewModelWork
            {
                Id= w.Id,
                City= _context.Cities.Where(c => c.PlateCode == w.PlateCode).FirstOrDefault().Name,
                Country = _context.Countries.Where(c => c.Id == w.CountryId).FirstOrDefault().Name,
                Description = w.Description,
                User = w.UserId
            }).FirstOrDefault();

            return data;
        }

        public void InsertWork(ViewModelInsertWork work)
        {
            var data = new Work();
            data.Description = work.Description;
            data.UserId = work.UserId;
            data.PlateCode = work.PlateCode;
            data.CountryId = work.CountryId;
            data.AddedDate = work.AddedDate;
            data.ModifiedDate = work.AddedDate;
            
            

            _context.Works.Add(data);

        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void UpdateWork(ViewModelUpdateWork work)
        {
            var data = _context.Works.Find(work.Id);
            data.PlateCode= work.PlateCode;
            data.CountryId = work.CountryId;
            data.Description= work.Description;
            data.ModifiedDate = work.ModifiedDate;
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
