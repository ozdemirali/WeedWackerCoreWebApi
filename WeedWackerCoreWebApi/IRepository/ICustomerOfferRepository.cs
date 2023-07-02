using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.IRepository
{
    public interface ICustomerOfferRepository:IDisposable
    {
        IEnumerable<ViewModelCustomerOffer> GetOffers(string id);
    }
}
