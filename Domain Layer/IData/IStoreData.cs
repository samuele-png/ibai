using Domain_Layer.Classes;
using Domain_Layer.Enums;

namespace Domain_Layer.Interfaces
{
    public interface IStoreData
    {
        List<Store> GetStores();
        Store GetStore(Store store);
        Store GetStoreByName(Store store);
        List<Categories> GetCategories(Store store);
        void WriteStore(Store store);
        
        void DeleteStore(Store store);
        void UpdateStore(Store store);
    }
}
