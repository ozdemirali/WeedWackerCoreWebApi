using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using WeedWackerCoreWebApi.Context;
using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.IRepository;

namespace WeedWackerCoreWebApi.Repository
{
    public class UploadRepository : IUploadRepository, IDisposable
    {
        private WeedWackerDbContext _context;
        private bool disposed = false;

        public UploadRepository(WeedWackerDbContext context)
        {
            this._context = context;
        }

        public string Upload(IFormFile file)
        {
            try
            {
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return fileName;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Upload Repository -  Upload(bool disposing)",
                };
                _context.Errors.Add(error);
            }
            throw new NotImplementedException();
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
                    Place = "Upload Repository -  Dispose(bool disposing)",
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
                    Place = "Upload Repository -  Dispose()",
                };
                _context.Errors.Add(error);
            }


        }
    }
}
