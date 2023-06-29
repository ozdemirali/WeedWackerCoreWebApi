using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private IOfferRepository _offerRepository;
        public OfferController(IOfferRepository offerRepository)
        {
            this._offerRepository = offerRepository;
        }

        [HttpGet("{workId}")]
        public IEnumerable<ViewModelOffer> Get(Int64 workId)
        {
           
            return _offerRepository.GetOffers(workId); ;
        }
    }
}
