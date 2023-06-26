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

        [HttpGet]
        public IEnumerable<ViewModelWork> GetWorkAll()
        {
            return _workRepository.GetWorkAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewModelWork>> GetWorkById(long id)
        {
            var work=_workRepository.GetWorkById(id);
           
            return work;
        }

        [HttpPost]
        public IActionResult PostWork(ViewModelInsertWork work)
        {


            _workRepository.InsertWork(work);
            if (_workRepository.Save() > 0)
            {
                return Ok("Ok");
            }

            return NoContent();
        }

        [HttpPut]
        public  IActionResult PutWork(ViewModelUpdateWork work)
        {
            _workRepository.UpdateWork(work);
            if (_workRepository.Save()>0)
            {
                return Ok("Ok");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWork(long id)
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
