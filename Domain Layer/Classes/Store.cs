using Domain_Layer.Enums;

namespace Domain_Layer.Classes
{
    public class Store
    {
        public Store(int storeId) { StoreId = storeId; }
        public Store (string storeName) { StoreName = storeName; }

        public Store(int storeId, User owner, string storeName, string description, List<Categories> categories)
        {
            StoreName = storeName;
            StoreId = storeId;
            Owner = owner;
            Description = description;
            Categories = categories;
        }
        public string StoreName { get; private set; }
        public int StoreId { get; private set; }
        public User Owner { get; private set; }
        public string Description { get; private set; }
        public List<Categories> Categories { get; private set; }

    }
}
