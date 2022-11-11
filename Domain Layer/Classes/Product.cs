using Domain_Layer.Enums;
namespace Domain_Layer.Classes
{
    public class Product
    {
        public Product(int productId)
        {
            ProductID = productId;
        }
        public Product(int productId, string name, string description, double? price, double? shippingFee,
            string pictureUrl,List<Categories> categories, Store store)
        {
            ProductID = productId;
            Name = name;
            Description = description;
            Price = price;
            ShippingFee = shippingFee;
            PictureUrl = pictureUrl;
            Store = store;
            Categories = categories;
        }
        public int ProductID { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public double? Price { get; private set; }
        public double? ShippingFee { get; private set; }
        public Store Store { get; private set; }
        public List<Categories> Categories { get; private set; }
        public string PictureUrl { get; private set; }
    }
}
