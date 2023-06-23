using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
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

    }
}
