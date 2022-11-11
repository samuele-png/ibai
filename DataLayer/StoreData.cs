using Domain_Layer.Classes;
using Domain_Layer.Enums;
using Domain_Layer.Interfaces;
using MySql.Data.MySqlClient;
using System.Text;

namespace DataLayer
{
    public class StoreData : IStoreData
    {
        private const string connectionString = @"Server=studmysql01.fhict.local;Uid=dbi501256;Database=dbi501256;Pwd=12345;";
        public void WriteStore(Store store)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                foreach (Categories x in store.Categories)
                {
                    sb.Append(x + ",");
                }
                MySqlConnection conn = new MySqlConnection(connectionString);
                string storeCats = sb.ToString();
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO store_data(ID,Owner,StoreName,Description,Categories) VALUES(@ID,@Owner,@StoreName,@Description,@Categories) ", conn);
                cmd.Parameters.AddWithValue("@ID", store.StoreId);
                cmd.Parameters.AddWithValue("@Owner", store.Owner.UserId);
                cmd.Parameters.AddWithValue("@StoreName", store.StoreName);
                cmd.Parameters.AddWithValue("@Description", store.Description);
                //FIX THIS FIRST
                cmd.Parameters.AddWithValue("@Categories", storeCats);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured:" + e.Message + "\t" + e.GetType());
            }
        }
        public List<Store> GetStores()
        {
            StoreData sData = new();
            UserData uData = new();
            List<Store> stores = new List<Store>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM store_data", conn);
            conn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                stores.Add(new Store(Convert.ToInt32(reader[0]), uData.GetUserById(new User(Convert.ToInt32(reader[1]))), reader[2].ToString(), reader[3].ToString(), sData.GetCategories(new Store(Convert.ToInt32(reader[0])))
                    ));
            conn.Close();
            return stores;
        }

        public Store GetStore(Store store)
        {
            Store selStore = new Store(store.StoreId);
            var cnn = new MySqlConnection(connectionString);
            var cmd = new MySqlCommand("SELECT * FROM STORE_DATA WHERE ID=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", store.StoreId);
                cnn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                selStore = (new Store(Convert.ToInt32(reader[0]), new User(store.Owner.UserId), reader[2].ToString(), reader[3].ToString(), GetCategories(new Store(Convert.ToInt32(reader[0])))));
            cnn.Close();
            return selStore;
        }
        public Store GetStoreByName(Store store)
        {
            //should be done differently. not with the new Store(0) but rather by passing down user?
            Store selStore = new Store(0);
            var cnn = new MySqlConnection(connectionString);
            var cmd = new MySqlCommand("SELECT * FROM STORE_DATA WHERE StoreName=@StoreName", cnn);
            cmd.Parameters.AddWithValue("@StoreName", store.StoreName);
            cnn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                selStore = (new Store(Convert.ToInt32(reader[0]),new User(Convert.ToInt32(reader[1])), reader[2].ToString(), reader[3].ToString(), GetCategories(new Store(Convert.ToInt32(reader[0])))));
            cnn.Close();
            return selStore;
        }

        public List<Categories> GetCategories(Store store)
        {
            List<Categories> cList = new();
            var cnn = new MySqlConnection(connectionString);
            var cmd = new MySqlCommand("SELECT Categories FROM store_data WHERE `ID`=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", store.StoreId);
            cnn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                
                foreach (string x in reader[0].ToString().Split(','))
                {
                    if(x!="")
                    cList.Add((Enum.Parse<Categories>(x)));
                }
            cnn.Close();
            return cList;
        }
        public void DeleteStore(Store store)
        {
            try
            {
                var conn = new MySqlConnection(connectionString);
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM store_data where `ID`=@ID");
                cmd.Parameters.AddWithValue("@ID", store.StoreId);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured:" + e.Message + "\t" + e.GetType());
            }
        }
        //TODO USER UPDATE CRUD
        public void UpdateStore(Store store)
        {
            string storeCats;
            foreach (Categories x in store.Categories)
            {
                storeCats = string.Join(",", (int)x);
            }
            try
            {
                var conn = new MySqlConnection(connectionString);
                var commandText = "UPDATE store_data SET Owner=@Owner,StoreName=@StoreName,Description=@Description,Categories=@Categories WHERE `ID`=@ID";
                using var cmd = new MySqlCommand(commandText, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@ID", store.StoreId);
                cmd.Parameters.AddWithValue("@Owner", store.Owner.UserId);
                cmd.Parameters.AddWithValue("@StoreName", store.StoreName);
                cmd.Parameters.AddWithValue("@Description", store.Description);
                cmd.Parameters.AddWithValue("@Categories", store.Categories);
                var reader = cmd.ExecuteReader();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured:" + e.Message + "\t" + e.GetType());
            }
        }
    }
}
