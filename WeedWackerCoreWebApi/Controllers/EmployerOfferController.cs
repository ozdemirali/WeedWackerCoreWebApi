using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerOfferController : ControllerBase
    {
        private IEmployerOfferRepository _employerOfferRepository;
        public EmployerOfferController(IEmployerOfferRepository employerOfferRepository)
        {
            this._employerOfferRepository = employerOfferRepository;
        }

        [HttpGet("{id}")]
        public IEnumerable<ViewModelEmployerOffer> Get(string id)
        {
            return _employerOfferRepository.GetOffers(id);
        }

        [HttpPost]
        public ActionResult Post(ViewModelEmployerOffer offer)
        {
            _employerOfferRepository.InsertOffer(offer);
            if (_employerOfferRepository.Save() > 0)
            {
                return Ok("Ok");
            }
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put(ViewModelEmployerOffer offer)
        {
            _employerOfferRepository.UpdateOffer(offer);
            if (_employerOfferRepository.Save() > 0)
            {
                return Ok("Ok");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Int64 id)
        {
            _employerOfferRepository.DeleteOffer(id);

            if (_employerOfferRepository.Save() > 0)
            {
                return Ok("Ok");
            }
            return NoContent();
        }
    }
}
