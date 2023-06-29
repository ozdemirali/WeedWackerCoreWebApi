using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private IWorkRepository _workRepository;

        public WorkController(IWorkRepository workRepository)
        {
            this._workRepository = workRepository;
        }

        /// <summary>
        /// This method gets all data from Database by using workRepository pattern.
        /// </summary>
        /// <returns>All Work</returns>
        [HttpGet]
        public IEnumerable<ViewModelWork> Get()
        {
            return _workRepository.GetWorks();
        }

        [HttpGet("{id}")]
        public ActionResult<ViewModelWork> GetById(long id)
        {
            var work = _workRepository.GetWorkById(id);

            if (work == null)
            {
                return NotFound();
            }

            return work;
        }

        [HttpPost]
        public IActionResult Post(ViewModelInsertWork work)
        {
            _workRepository.InsertWork(work);
            if (_workRepository.Save() > 0)
            {
                return Ok("Ok");
            }

            return NoContent();
        }

        [HttpPut]
        public  IActionResult Put(ViewModelUpdateWork work)
        {
            
            _workRepository.UpdateWork(work);
            if (_workRepository.Save()>0)
            {
                return Ok("Ok");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
           
            _workRepository.DeleteWork(id);
            if (_workRepository.Save() > 0)
            {
                return Ok("Ok");
            }

            return NoContent();
        }

    }
}
