using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeedWackerCoreWebApi.IRepository;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private ISettingRepository _settingRepository;

        public SettingController(ISettingRepository settingRepository)
        {
            this._settingRepository = settingRepository;
        }

        [HttpGet]
        public IEnumerable<ViewModelSetting> Get()
        {
            return _settingRepository.GetSettings(); 
        }

        [HttpGet("{id}")]
        public ActionResult<ViewModelSetting> GetById(string id)
        {
            var setting = _settingRepository.GetSettingById(id);
            if (setting == null)
            {
                return NotFound();
            }
            return setting;

        }

        [HttpPost]
        public ActionResult Post(ViewModelSetting setting)
        {
            var data = _settingRepository.GetSettingById(setting.Id);
            if (data == null)
            {
                _settingRepository.InsertStting(setting);
                if (_settingRepository.Save() > 0)
                {
                    return Ok("Ok");
                }
                return NoContent();
            }

            return Ok("Already Registered");
        }

        [HttpPut]
        public ActionResult Put(ViewModelSetting setting)
        {
            _settingRepository.UpdateSetting(setting);
            if (_settingRepository.Save() > 0)
            {
                return Ok("Ok");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _settingRepository.DeleteSetting(id);
            if (_settingRepository.Save() > 0)
            {
                return Ok("Ok");
            }
            return NoContent();
        }
    }


}
