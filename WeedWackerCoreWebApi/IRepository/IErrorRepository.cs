using WeedWackerCoreWebApi.Entity;

namespace WeedWackerCoreWebApi.IRepository
{
    public interface IErrorRepository:IDisposable
    {
        void InsertError(Error error);
        
    }
}
