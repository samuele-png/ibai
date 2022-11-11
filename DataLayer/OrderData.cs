 using Domain_Layer.Classes;
using Domain_Layer.Interfaces;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace DataLayer
{
    public class OrderData : IOrderData
    {
        private const string connectionString = @"Server=studmysql01.fhict.local;Uid=dbi501256;Database=dbi501256;Pwd=12345;";
        //supposed to run only after payment
        public void WriteOrder(Order order)
        {
            try
            {
                var conn = new MySqlConnection(connectionString);
                List<Product> products = new List<Product>(order.Products);
                conn.Open();
                var cmd = new MySqlCommand();
                foreach (Product productId in products)
                {
                    cmd = new MySqlCommand("INSERT INTO order_data(ID,UserId) VALUES(@orderID,@);" +
             "INSERT INTO order_list_details(ID,orderID,productID) VALUES(@detailsID,@orderID,productID", conn);
                    cmd.Parameters.AddWithValue("@orderID", order.OrderId);
                    cmd.Parameters.AddWithValue("@UserId", order.User.UserId);
                    cmd.Parameters.AddWithValue("detailsID", 0);
                    cmd.Parameters.AddWithValue("productID", productId);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException();            }
        }
        public Order GetOrder(Order order)
        {
            Order selOrder = new Order(order.OrderId);
            var cnn = new MySqlConnection(connectionString);
            var cmd = new MySqlCommand("SELECT order_list_data.productID " +
                "FROM order_data " +
                "INNER JOIN order_list_data " +
                "ON order_data.OrderId=order_list_data.orderID " +
                "WHERE order_data.OrderId = @OrderId", cnn);
            cmd.Parameters.AddWithValue("@OrderId", order.OrderId);
            cnn.Open();
            var reader = cmd.ExecuteReader();
            List<Product> productList = new List<Product>();
            foreach (Product product in reader)
            {
                productList.Add(product);
            }
            while (reader.Read())
                selOrder.User = order.User;
            selOrder.Products = productList;

            cnn.Close();
            return selOrder;
        }
        //should go to usermanager or not?
        public List<Order> GetOrders()
        {
            ProductData productData = new();
            List<Order> orders = new List<Order>();
            var cnn = new SqlConnection(connectionString);
            var commandText = "SELECT * FROM order_data";
            using var cmd = new SqlCommand(commandText, cnn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                orders.Add(new Order(Convert.ToInt32(reader[0]), new User(Convert.ToInt32(reader[1])), GetOrder(new Order(Convert.ToInt32(reader[0]))).Products));
            cnn.Close();
            return orders;
        }
        public void DeleteOrder(Order order)
        {
            try
            {
                var conn = new MySqlConnection(connectionString);
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM order_data WHERE ID=@ID");
                cmd.Parameters.AddWithValue("@ID", order.OrderId);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured:" + e.Message + "\t" + e.GetType());
            }
        }
        //TODO ORDER UPDATE CRUD
        public void UpdateOrder(Order order)
        {   /*
            var cnn = new MySqlConnection(connectionString);
            var commandText = "UPDATE order_data SET OrderId=@OrderId, UserId=@UserID WHERE `ID`=@ID";
            using var cmd = new MySqlCommand(commandText, cnn);
            //cmd.Parameters.AddWithValue("@Name", .Name);
            cnn.Open(); var reader = cmd.ExecuteReader();
            cnn.Close();
            */
            throw new NotImplementedException();
        }
    }
}
