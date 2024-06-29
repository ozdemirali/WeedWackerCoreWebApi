using System.Numerics;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.IRepository
{
    public interface IDistrictRepository:IDisposable
    {
        IEnumerable<ViewModelDistrict> GetDistrictsById(int plateCode);
        string GetDistrictName(int districtId);
        int Save();
    }
}
