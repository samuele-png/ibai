using Domain_Layer.Classes;
using Domain_Layer.Interfaces;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class StockData : IStockData
    {
        private const string connectionString = @"Server=studmysql01.fhict.local;Uid=dbi501256;Database=dbi501256;Pwd=12345;";
        public void WriteStock(Stock stock)
        {
            try
            {
                var conn = new MySqlConnection(connectionString);
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO stock_data(ID,ProductId,AmountInStock,SuggestedAmount) VALUES(@ID,@ProductId,@AmountInStock,@SuggestedAmount)", conn);
                cmd.Parameters.AddWithValue("@ID", 0);
                cmd.Parameters.AddWithValue("@ProductID", stock.Product.ProductID);
                cmd.Parameters.AddWithValue("@AmountInStock", stock.AmountInStock);
                cmd.Parameters.AddWithValue("@SuggestedAmount", stock.SuggestedAmount);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured:" + e.Message + "\t" + e.GetType());
            }
        }
        public List<Stock> GetStocks()
        {
            ProductData prd = new();
            List<Stock> stocks = new List<Stock>();
            var cnn = new MySqlConnection(connectionString);
            var cmd = new MySqlCommand("SELECT * FROM stock_data", cnn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                stocks.Add(new Stock(prd.GetProduct(new Product(Convert.ToInt32(reader[0]))), Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2])));
            cnn.Close();
            return stocks;
        }
        public Stock GetStock(Product product)
        {
            ProductData prd = new();
            Stock selStock = new(product);
            var cnn = new MySqlConnection(connectionString);
            var cmd = new MySqlCommand("SELECT * FROM stock_data WHERE `ID` = @ID");
            cmd.Parameters.AddWithValue("@ID", product.ProductID);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                selStock = new Stock(prd.GetProduct(new Product(Convert.ToInt32(reader[0]))), Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2]));
            cnn.Close();
            return selStock;
        }
        public void DeleteStock(Stock stock)
        {
            try
            {
                var conn = new MySqlConnection(connectionString);
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM STOCK_DATA WHERE @ID");
                cmd.Parameters.AddWithValue("@ID", stock.Product.ProductID);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured:" + e.Message + "\t" + e.GetType());
            }
        }
        public void UpdateStock(Stock stock)
        {
            var cnn = new MySqlConnection(connectionString);
            using var cmd = new MySqlCommand("UPDATE stock_data SET AmountInStock=@AmountInStock,SuggestedAmount=@SuggestedAmount WHERE `ID`= @ID", cnn);
            cmd.Parameters.AddWithValue("@ID", stock.Product.ProductID);
            cmd.Parameters.AddWithValue("@AmountInStock", stock.AmountInStock);
            cmd.Parameters.AddWithValue("@SuggestedAmount", stock.SuggestedAmount);
            cnn.Open();
            var reader = cmd.ExecuteReader();
            cnn.Close();
        }
    }
}
