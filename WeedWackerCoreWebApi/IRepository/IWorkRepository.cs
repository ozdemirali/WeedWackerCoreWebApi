using WeedWackerCoreWebApi.ViewModel;
using WeedWackerCoreWebApi.Entity;

namespace WeedWackerCoreWebApi.IRepository
{
    public interface IWorkRepository:IDisposable
    {
        IEnumerable<ViewModelWork> GetWorkAll();
        ViewModelWork GetWorkById(Int64 id);
        void InsertWork(ViewModelInsertWork work);
        void DeleteWork(Int64 id);
        void UpdateWork(ViewModelUpdateWork work);
        int Save();

    }
}
