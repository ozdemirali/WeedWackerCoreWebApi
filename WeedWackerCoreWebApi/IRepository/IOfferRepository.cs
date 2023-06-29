using System.Collections;
using WeedWackerCoreWebApi.ViewModel;

namespace WeedWackerCoreWebApi.IRepository
{
    public interface IOfferRepository:IDisposable
    {
        IEnumerable<ViewModelOffer> GetOffers(Int64 workId);
    }
}
