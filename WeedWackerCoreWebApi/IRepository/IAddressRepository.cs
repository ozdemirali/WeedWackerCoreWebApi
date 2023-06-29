using WeedWackerCoreWebApi.Entity;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.IRepository
{
    public interface IAddressRepository:IDisposable
    {
        IEnumerable<ViewModelAddress> GetAddress();
        ViewModelAddress GetAdressById(string id);
        void InsertAddress(ViewModelAddress address);
        void UpdateAddress(ViewModelAddress address);
        void DeleteAddress(string id);
        int Save();
    }
}
