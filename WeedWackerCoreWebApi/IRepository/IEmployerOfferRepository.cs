using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.IRepository
{
    public interface IEmployerOfferRepository:IDisposable
    {
        IEnumerable<ViewModelEmployerOffer> GetOffers(string id); 
        void InsertOffer(ViewModelEmployerOffer offer);
        void UpdateOffer(ViewModelEmployerOffer offer);
        void DeleteOffer(Int64 id);
        int Save();
    }
}
