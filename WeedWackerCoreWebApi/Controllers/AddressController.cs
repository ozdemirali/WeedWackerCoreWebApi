﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class AddressController : ControllerBase
    {
        private IAddressRepository _addressRepository;
        private ICityRepository _cityRepository;
        private IDistrictRepository _districtRepository;
        private IErrorRepository _errorRepository;
        public AddressController(IAddressRepository addressRepository,ICityRepository cityRepository ,IDistrictRepository districtRepository,IErrorRepository errorRepository)
        {
            this._addressRepository = addressRepository;
            this._cityRepository = cityRepository;
            this._districtRepository = districtRepository;  
            this._errorRepository = errorRepository;
        }

        /// <summary>
        /// This method gets All data from Database 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ViewModelAddress> Get()
        {
            try
            {
                return _addressRepository.GetAddress();
            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Address Controller - Get()",
                };

                _errorRepository.InsertError(error);

                return Enumerable.Empty<ViewModelAddress>();
            }
           
        }

        /// <summary>
        /// This method gets only one object acording to id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ViewModelAddressShow> GetById(string id)
        {
            try
            {
                var address = _addressRepository.GetAdressById(id);
                ViewModelAddressShow result = new ViewModelAddressShow();
                if (address == null)
                {
                    return NotFound();
                }

                result.Id=address.Id;
                result.City = _cityRepository.GetCityById(address.PlateCode).Name;
                result.District = _districtRepository.GetDistrictName(address.DistrictId);
                result.Phone=address.Phone;
                result.AddInfo=address.AddInfo;
                result.PostCode=address.PostCode;
                return result;
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
              
                return new ViewModelAddressShow();
            }

           
        }

       

        /// <summary>
        /// This method insert new record into database
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post(ViewModelAddress address)
        {

            try
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
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Address Controller - Post()",
                };

                _errorRepository.InsertError(error);
                
                return Ok(e.Message);
            }
            
        }

        /// <summary>
        /// This method update object
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Put(ViewModelAddress address) {

            try
            {
                _addressRepository.UpdateAddress(address);
                if (_addressRepository.Save() > 0)
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
                    Place = "Address Controller - Put()",
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
        public ActionResult Delete(string id)
        {

            try
            {
                _addressRepository.DeleteAddress(id);
                if (_addressRepository.Save() > 0)
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
                    Place = "Address Controller - Delete()",
                };

                _errorRepository.InsertError(error);

                return Ok(e.Message);
            }
           
        }
    }
}
