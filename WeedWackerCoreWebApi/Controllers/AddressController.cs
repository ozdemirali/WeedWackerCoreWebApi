using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.Repository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressRepository _addressRepository;
        public AddressController(IAddressRepository addressRepository)
        {
            this._addressRepository = addressRepository;
        }

        [HttpGet]
        public IEnumerable<ViewModelAddress> Get()
        {
            return _addressRepository.GetAddress();
        }

        [HttpGet("{id}")]
        public ActionResult<ViewModelAddress> GetById(string id)
        {
            var address=_addressRepository.GetAdressById(id);
            if (address == null)
            {
                return NotFound();
            }
            return address;
        }

        [HttpPost]
        public ActionResult Post(ViewModelAddress address)
        {

            var data = _addressRepository.GetAdressById(address.Id);
            if (data == null)
            {
                _addressRepository.InsertAddress(address);
                if (_addressRepository.Save() > 0)
                {
                    return Ok("Ok");
                }
                return NoContent();
            }
           
            
            return Ok("Already Registered");
        }

        [HttpPut]
        public ActionResult Put(ViewModelAddress address) { 
          _addressRepository.UpdateAddress(address);
            if (_addressRepository.Save() > 0)
            {
                return Ok("Ok");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _addressRepository.DeleteAddress(id);
            if (_addressRepository.Save() > 0)
            {
                return Ok("Ok");
            }
            return NoContent();
        }
    }
}
