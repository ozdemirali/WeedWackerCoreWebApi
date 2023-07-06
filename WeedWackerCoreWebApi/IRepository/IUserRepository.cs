using WeedWackerCoreWebApi.Model;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.IRepository
{
    public interface IUserRepository:IDisposable
    {
        CurrentUser ControlUser(ViewModelUser user);
    }
}
