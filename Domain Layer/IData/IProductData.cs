using Domain_Layer.Classes;
using Domain_Layer.Enums;

namespace Domain_Layer.Interfaces
{
    public interface IProductData
    {
        List<Product> GetProducts();
        Product GetProduct(Product product);
        List<Categories> GetCategories(Product product);
        void WriteProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);

    }
}
