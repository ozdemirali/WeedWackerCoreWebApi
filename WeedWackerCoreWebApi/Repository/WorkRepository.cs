using WeedWackerCoreWebApi.Context;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.ViewModel;

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
            throw new NotImplementedException();
        }

        

        public IEnumerable<ViewModelWork> GetWorkAll()
        {
            var data = _context.Works.Select(w => new ViewModelWork
            {
                Id = w.Id,
                CountryId = w.CountryId,
                Description = w.Description,
                PlateCode = w.PlateCode,
                UserId = w.UserId
            }).ToList();
           
            return data;
        }

        public ViewModelWork GetWorkById(long id)
        {
            throw new NotImplementedException();
        }

        public void InsertWork(ViewModelWork work)
        {
            throw new NotImplementedException();
        }

        public int save()
        {
            throw new NotImplementedException();
        }

        public void UpdateWork(ViewModelWork work)
        {
            throw new NotImplementedException();
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
