using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.Repository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Customer")]

    public class CityController : ControllerBase
    {
        private ICityRepository _cityRepository;
        private IErrorRepository _errorRepository;

       
        public CityController(ICityRepository cityRepository,IErrorRepository errorRepository)
        {
            this._cityRepository = cityRepository;
            this._errorRepository = errorRepository;
        }

        /// <summary>
        /// This method gets all city data from Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<City> Get()
        {
            try
            {
                return _cityRepository.GetCities();
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "City Controller - Get()",
                };

                _errorRepository.InsertError(error);

                return Enumerable.Empty<City>();
            }
        }

        /// <summary>
        /// This method gets only one object acording to id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<City> GetById(int id)
        {
            try
            {
                var city = _cityRepository.GetCityById(id);
                if (city == null)
                {
                    return NotFound();
                }
                return city;
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Address Controller - GetById()",
                };

                _errorRepository.InsertError(error);

                return new City();
            }
        }
        /// <summary>
        /// This method insert new record into database
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post(City city)
        {
            try
            {
                var data = _cityRepository.GetCityById(city.PlateCode);
                if (data == null)
                {
                    _cityRepository.InsertCity(city);
                    if (_cityRepository.Save()>0)
                    {
                        return Ok("Ok");
                    }
                    return NoContent();
                }
                return Ok("Already Registered");
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "City Controller - Post()",
                };

                _errorRepository.InsertError(error);

                return Ok(e.Message);
            }
        }

        /// <summary>
        /// This method update object
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put(City city)
        {
            try
            {
                _cityRepository.UpdateCity(city);
                if (_cityRepository.Save() > 0)
                {
                    return Ok("Ok");
                }

                return NoContent();

            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "City Controller - Put()",
                };

                _errorRepository.InsertError(error);

                return Ok(e.Message);
            }
        }

        /// <summary>
        /// This method deletes only one record according to id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            try
            {
                _cityRepository.DeleteCity(id);
                if (_cityRepository.Save() > 0)
                {
                    return Ok("Ok");
                }
                return NoContent();
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "City Controller - Delete()",
                };

                _errorRepository.InsertError(error);

                return Ok(e.Message);
            }

        }

    }
}
