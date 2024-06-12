using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.Repository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private IUploadRepository _uploadRepository;
        private IErrorRepository _errorRepository;


        public UploadController(IUploadRepository uploadRepository, IErrorRepository errorRepository)
        {
            this._uploadRepository = uploadRepository;
            this._errorRepository = errorRepository;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadAsync()
        {
            try
            {
                var formcollection = await Request.ReadFormAsync();
                var file = formcollection.Files.First();

                var filename = _uploadRepository.Upload(file);
                if (filename!="")
                {
                    return Ok(new { message = "Ok", fileName =filename  });

                }
                else
                {
                    return BadRequest();
                }
                
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Upload Controller - UploadAsync()",
                };

                _errorRepository.InsertError(error);

                return Ok(e.Message);
            }
        }
    }
}
