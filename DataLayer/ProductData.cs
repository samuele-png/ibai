using Domain_Layer.Classes;
using Domain_Layer.Interfaces;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using Domain_Layer.Enums;
using System.ComponentModel;

namespace DataLayer
{
    public class ProductData : IProductData
    {
        private const string connectionString = @"Server=studmysql01.fhict.local;Uid=dbi501256;Database=dbi501256;Pwd=12345;";
        public void WriteProduct(Product product)
        {
            try
            {
                var conn = new MySqlConnection(connectionString);
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO product_data(ID,Name,Description,Price,ShippingFee,PictureUrl,StoreId) VALUES(@ID,@Name,@Description,@Price,@ShippingFee,@Category,@PictureUrl,@StoreId)", conn);
                cmd.Parameters.AddWithValue("@ID", product.ProductID);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@ShippingFee", product.ShippingFee);
                cmd.Parameters.AddWithValue("@PictureUrl", product.PictureUrl);
                cmd.Parameters.AddWithValue("@StoreId", product.Store.StoreId);
                cmd.Parameters.AddWithValue("@Categories", product.Categories);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured:" + e.Message + "\t" + e.GetType());
            }
        }
        //pass object or only ID?
        public Product GetProduct(Product product)
        {
            Product selProduct = new Product(product.ProductID);
            var cnn = new MySqlConnection(connectionString);
            var cmd = new MySqlCommand("SELECT * FROM PRODUCT_DATA WHERE ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", product.ProductID);
            cnn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                selProduct = new Product(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), Convert.ToDouble(reader[3]), Convert.ToDouble(reader[4]), reader[5].ToString(), GetCategories(new Product(Convert.ToInt32(reader[0]))), new Store(Convert.ToInt32(reader[7])));
            cnn.Close();
            return selProduct;
        }
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            var cnn = new MySqlConnection(connectionString);
            var commandText = "SELECT * FROM product_data";
            using var cmd = new MySqlCommand(commandText, cnn);
            Product newProduct;
            cnn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                //TODO
                products.Add(new Product(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), Convert.ToDouble(reader[3]), Convert.ToDouble(reader[4]), reader[5].ToString(), GetCategories(new Product(Convert.ToInt32(reader[0]))), new Store(Convert.ToInt32(reader[7]))));
            cnn.Close();
            return products;
        }
        public List<Categories> GetCategories(Product product)
        {
          
            List<Categories> cList = new();
            var cnn = new MySqlConnection(connectionString);
            var cmd = new MySqlCommand("SELECT Categories FROM product_data WHERE `ID`=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", product.ProductID);
            cnn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                try
                {
                    foreach (string x in reader[0].ToString().Split(','))
                    {//TODO
                        // cList.Add((Enum.Parse<Categories>(x)));
                        cList = new List<Categories>();
                        Categories categories = Categories.Music;
                        cList.Add(categories);

                    }
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("Exception occured:" + e.Message + "\t" + e.GetType());

                }

            cnn.Close();
            return cList;
        }
        public void DeleteProduct(Product product)
        {
            try
            {
                var conn = new MySqlConnection(connectionString);
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM product_data WHERE @ID");
                cmd.Parameters.AddWithValue("@ID", product.ProductID);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured:" + e.Message + "\t" + e.GetType());
            }
        }
        public void UpdateProduct(Product product)
        {
            var cnn = new MySqlConnection(connectionString);
            var commandText = "UPDATE product_data SET Name=@Name,Price=@Price,Description=@Description,ShippingFee=@ShippingFee,PictureUrl=@PictureUrl,StoreId=@StoreId WHERE `ID`=@ID";
            using var cmd = new MySqlCommand(commandText, cnn);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@ShippingFee", product.ShippingFee);
            cmd.Parameters.AddWithValue("@PictureUrl", product.PictureUrl);
            cmd.Parameters.AddWithValue("@StoreId", product.Store.StoreId);
            cnn.Open();
            var reader = cmd.ExecuteReader();
            cnn.Close();
        }
    }
}
