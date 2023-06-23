using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.IRepository
{
    public interface IWorkRepository:IDisposable
    {
        IEnumerable<ViewModelWork> GetWorkAll();
        ViewModelWork GetWorkById(Int64 id);
        void InsertWork(ViewModelWork work);
        void DeleteWork(Int64 id);
        void UpdateWork(ViewModelWork work);
        int save();

    }
}
