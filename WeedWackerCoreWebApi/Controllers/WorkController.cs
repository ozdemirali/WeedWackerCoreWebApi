using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.Repository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private IWorkRepository _workRepository;
        private IErrorRepository _errorRepository;

        public WorkController(IWorkRepository workRepository, IErrorRepository errorRepository)
        {
            this._workRepository = workRepository;
            this._errorRepository = errorRepository;
        }

        /// <summary>
        /// This method gets all data from Database by using workRepository pattern.
        /// </summary>
        /// <returns>All Work</returns>
        [HttpGet]
        public IEnumerable<ViewModelWork> Get()
        {
            try
            {
                return _workRepository.GetWorks();

            }
            catch (Exception e)
            {
                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Work Controller - Get()",
                };

                _errorRepository.InsertError(error);

                return Enumerable.Empty<ViewModelWork>();
            }
        }


        /// <summary>
        /// This method gets one work by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ViewModelWork> GetById(long id)
        {
            try
            {
                var work = _workRepository.GetWorkById(id);

                if (work == null)
                {
                    return NotFound();
                }

                return work;
            }
            catch (Exception e)
            {

                Error error = new()
                {
                    Id = Guid.NewGuid(),
                    Message = e.Message,
                    Place = "Work Controller - GetById()",
                };

                _errorRepository.InsertError(error);

                return new ViewModelWork();
            }

           
        }


        /// <summary>
        /// This method recors a new work
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ViewModelInsertWork work)
        {
            try
            {
                _workRepository.InsertWork(work);
                if (_workRepository.Save() > 0)
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
                    Place = "Work Controller - Post()",
                };

                _errorRepository.InsertError(error);

                return Ok(e.Message);
            }

            
        }


        /// <summary>
        /// This method updates a record
        /// </summary>
        /// <param name="work"></param>
        /// <returns></returns>
        [HttpPut]
        public  IActionResult Put(ViewModelUpdateWork work)
        {

            try
            {
                _workRepository.UpdateWork(work);
                if (_workRepository.Save() > 0)
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
                    Place = "Work Controller - Put()",
                };

                _errorRepository.InsertError(error);

                return Ok(e.Message);
            }

            
        }

        /// <summary>
        /// This method deletes one record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {

            try
            {
                _workRepository.DeleteWork(id);
                if (_workRepository.Save() > 0)
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
                    Place = "Work Controller - Delete()",
                };

                _errorRepository.InsertError(error);

                return Ok(e.Message);
            }
           
        }

    }
}
