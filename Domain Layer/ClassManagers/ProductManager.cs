using Domain_Layer.Classes;
using Domain_Layer.Enums;
using Domain_Layer.Interfaces;

namespace Domain_Layer.ClassManagers
{
    public class ProductManager
    {//take interface and inject it into the constructor of the manager
     // magic happening


        IProductData _ProductData;

        public ProductManager(IProductData productData)
        {
            _ProductData = productData;
        }
        public void WriteProduct(Product product)
        {
            _ProductData.WriteProduct(product);
        }
        public List<Product> GetProducts()
        {
            return _ProductData.GetProducts();
        }
        public Product GetProduct(Product product)
        {
            return _ProductData.GetProduct(product);
        }
        public List<Categories> GetCategories(Product product)
        {
            return _ProductData.GetCategories(product);
        }

        public void DeleteProduct(Product product)
        {
            _ProductData.DeleteProduct(product);
        }

        public void UpdateSProduct(Product product)
        {
            _ProductData.UpdateProduct(product);
        }
    }
}
