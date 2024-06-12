using WeedWackerCoreWebApi.Entity;

namespace WeedWackerCoreWebApi.IRepository
{
    public interface ICityRepository
    {
        IEnumerable<City> GetCities();
        City GetCityById(int plateCode);
        void InsertCity(City city);
        void UpdateCity(City city);
        void DeleteCity(int plateCode);
        int Save();
    }
}
