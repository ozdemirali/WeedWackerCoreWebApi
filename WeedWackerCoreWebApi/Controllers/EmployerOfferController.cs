using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerOfferController : ControllerBase
    {
        private IEmployerOfferRepository _employerOfferRepository;
        private IErrorRepository _errorRepository;
        public EmployerOfferController(IEmployerOfferRepository employerOfferRepository, IErrorRepository errorRepository)
        {
            this._employerOfferRepository = employerOfferRepository;
            this._errorRepository = errorRepository;
        }

        /// <summary>
        /// This method gets all offer which are given by yourself. This id from here is EmployerId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IEnumerable<ViewModelEmployerOffer> Get(string id)
        {
            try
            {
                return _employerOfferRepository.GetOffers(id);

            }
            catch (Exception e)
            {

                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "EmployerOffer Controller - Get(string id)",
                };

                _errorRepository.InsertError(error);

                return Enumerable.Empty<ViewModelEmployerOffer>();
            }

        }

        
        /// <summary>
        /// A Employer give new offer by this method
        /// </summary>
        /// <param name="offer"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post(ViewModelEmployerOffer offer)
        {

            try
            {
                _employerOfferRepository.InsertOffer(offer);
                if (_employerOfferRepository.Save() > 0)
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
                    Place = "EmployerOffer Controller - Post(ViewModelEmployerOffer offer)",
                };

                _errorRepository.InsertError(error);
                return Ok(e.Message);
            }

           
        }

        /// <summary>
        /// A offer is updated by this method
        /// </summary>
        /// <param name="offer"></param>
        /// <returns></returns>

        [HttpPut]
        public ActionResult Put(ViewModelEmployerOffer offer)
        {
            try
            {
                _employerOfferRepository.UpdateOffer(offer);
                if (_employerOfferRepository.Save() > 0)
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
                    Place = "EmployerOffer Controller - Put(ViewModelEmployerOffer offer)",
                };

                _errorRepository.InsertError(error);
                return Ok(e.Message);
            }

           
        }

        /// <summary>
        /// This method delete one offer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(Int64 id)
        {
            try
            {
                _employerOfferRepository.DeleteOffer(id);

                if (_employerOfferRepository.Save() > 0)
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
                    Place = "EmployerOffer Controller -  Delete(Int64 id)",
                };

                _errorRepository.InsertError(error);
                return Ok(e.Message);
            }
           
        }
    }
}
