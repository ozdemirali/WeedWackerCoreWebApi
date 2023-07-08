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
            try
            {
                var data = _context.Works.Find(id);
                _context.Works.Remove(data);
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Work Repository - DeleteAddress(long id)",
                };
                _context.Errors.Add(error);
            }
        }

        

        public IEnumerable<ViewModelWork> GetWorks()
        {
            try
            {
                var data = _context.Works.Select(w => new ViewModelWork
                {
                    Id = w.Id,
                    City = _context.Cities.Where(c => c.PlateCode == w.PlateCode).FirstOrDefault().Name,
                    Country = _context.Countries.Where(c => c.Id == w.CountryId).FirstOrDefault().Name,
                    Description = w.Description,
                    Image = w.Image,
                    User = w.UserId
                }).ToList();

                return data;
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Work Repository - GetWorks()",
                };
                _context.Errors.Add(error);

                return Enumerable.Empty<ViewModelWork>();
            }
           
        }

        public ViewModelWork GetWorkById(long id)
        {
            try
            {
                var data = _context.Works.Where(w => w.Id == id).Select(w => new ViewModelWork
                {
                    Id = w.Id,
                    City = _context.Cities.Where(c => c.PlateCode == w.PlateCode).FirstOrDefault().Name,
                    Country = _context.Countries.Where(c => c.Id == w.CountryId).FirstOrDefault().Name,
                    Description = w.Description,
                    Image = w.Image,
                    User = w.UserId
                }).FirstOrDefault();

                return data;
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Work Repository - GetWorkById(long id)",
                };
                _context.Errors.Add(error);
                return new ViewModelWork();
            }

            
        }

        public void InsertWork(ViewModelInsertWork work)
        {
            try
            {
                var data = new Work
                {
                    AddedDate = DateTime.Now,
                    CountryId = work.CountryId,
                    Description = work.Description,
                    Image = work.Image,
                    PlateCode = work.PlateCode,
                    UserId = work.UserId,
                };

                _context.Works.Add(data);
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Work Repository - InsertWork(ViewModelInsertWork work)",
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
                    Place = "Work Repository - Save()",
                };
                _context.Errors.Add(error);
                return 0;
            }
        }

        public void UpdateWork(ViewModelUpdateWork work)
        {
            try
            {
                var data = _context.Works.Find(work.Id);
                data.PlateCode = work.PlateCode;
                data.CountryId = work.CountryId;
                data.Description = work.Description;
                data.Image = work.Image;
                data.ModifiedDate = work.ModifiedDate;
                _context.Entry(data).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Work Repository - UpdateWork(ViewModelUpdateWork work)",
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
                    Place = "Work Repository - Dispose(bool disposing)",
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
                    Place = "Work Repository - Dispose()",
                };
                _context.Errors.Add(error);
            }
            
        }
    }
}
