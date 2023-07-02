using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOfferController : ControllerBase
    {
        private ICustomerOfferRepository _customerOfferRepository;
        public CustomerOfferController(ICustomerOfferRepository customerOfferRepository)
        {
            this._customerOfferRepository = customerOfferRepository;
        }

        [HttpGet("{id}")]
        public IEnumerable<ViewModelCustomerOffer> Get(string id)
        {
            return _customerOfferRepository.GetOffers(id);
        }

    }
}
