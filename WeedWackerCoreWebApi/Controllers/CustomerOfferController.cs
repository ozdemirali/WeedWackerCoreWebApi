using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOfferController : ControllerBase
    {
        private ICustomerOfferRepository _customerOfferRepository;
        private IErrorRepository _errorRepository;
        public CustomerOfferController(ICustomerOfferRepository customerOfferRepository, IErrorRepository errorRepository)
        {
            this._customerOfferRepository = customerOfferRepository;
            this._errorRepository = errorRepository;
        }


        /// <summary>
        /// This method gets all offers which come from employers for customer - This id from here is customerId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IEnumerable<ViewModelCustomerOffer> Get(string id)
        {
            try
            {
                return _customerOfferRepository.GetOffers(id);
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "CustomerOffer Controller - Get(string id)",
                };
                
                _errorRepository.InsertError(error);
                
                return Enumerable.Empty<ViewModelCustomerOffer>(); ;
            }

        }

    }
}
