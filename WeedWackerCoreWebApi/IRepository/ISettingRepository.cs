using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.IRepository
{
    public interface ISettingRepository:IDisposable
    {
        IEnumerable<ViewModelSetting> GetSettings();
        ViewModelSetting GetSettingById(string id);
        void InsertStting (ViewModelSetting setting);
        void UpdateSetting (ViewModelSetting setting);
        void DeleteSetting (string id);
        int Save();

    }
}
