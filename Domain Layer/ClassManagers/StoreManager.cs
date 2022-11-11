using Domain_Layer.Classes;
using Domain_Layer.Enums;
using Domain_Layer.Interfaces;
namespace Domain_Layer.ClassManagers
{
    public class StoreManager
    {//take interface and inject it into the constructor of the manager


        IStoreData _StoreData;
        public StoreManager(IStoreData storeData)
        {
            _StoreData = storeData;
        }
        public void WriteStore(Store store)
        {
            _StoreData.WriteStore(store);
        }
        public List<Store> GetStores()
        {
            return _StoreData.GetStores();
        }
        public List<Categories> GetCategories(Store store)
        {
            return _StoreData.GetCategories(store);
        }
        public Store GetStore(Store store)
        {
            return _StoreData.GetStore(store);
        }
        public Store GetStoreByName(Store store)
        {
            return _StoreData.GetStoreByName(store);
        }
        public void DeleteStore(Store store)
        {
            _StoreData.DeleteStore(store);
        }
        public void UpdateStore(Store store)
        {
            _StoreData.UpdateStore(store);
        }
    }
}
