namespace WeedWackerCoreWebApi.IRepository
{
    public interface IUploadRepository:IDisposable
    {
        string Upload(IFormFile file);
    }
}
