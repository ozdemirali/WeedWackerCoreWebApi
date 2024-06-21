using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private IDistrictRepository _districtRepository;
        private IErrorRepository _errorRepository;

        public DistrictController(IDistrictRepository districtRepository,IErrorRepository errorRepository)
        {
            this._districtRepository = districtRepository;
            this._errorRepository = errorRepository;
        }


        [HttpGet("{plateCode}")]
        [Authorize(Roles = "Admin,Customer")]
        public IEnumerable<ViewModelDistrict> GetByPlateCode(int plateCode)
        {
            try
            {
                
                return _districtRepository.GetDistrictsById(plateCode); ;

            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "District Controller - GetById()",
                };

                _errorRepository.InsertError(error);

                return Enumerable.Empty<ViewModelDistrict>();
            }
        }  
    }
}
