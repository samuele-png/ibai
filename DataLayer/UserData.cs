using Domain_Layer.Classes;
using Domain_Layer.Interfaces;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    
    public class UserData : IUserData
    {
        private const string connectionString = @"Server=studmysql01.fhict.local;Uid=dbi501256;Database=dbi501256;Pwd=12345;";
        public void WriteUser(User user)
        {
            string hashedPassword = PasswordHandler.HashPassword(user.Password);
            try
            {
                var conn = new MySqlConnection(connectionString);
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO USER_DATA(ID,LastName,FirstName,Email,UserLevel,UserName,Password,TelephoneNumber,Address) VALUES(@ID,@LastName,@FirstName,@Email,@UserLevel,@UserName,@Password,@TelephoneNumber,@Address)", conn);
                cmd.Parameters.AddWithValue("@ID", user.UserId);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@UserLevel", user.UserLevel);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Password", hashedPassword);
                cmd.Parameters.AddWithValue("@TelephoneNumber", user.TelephoneNumber);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured:" + e.Message + "\t" + e.GetType());
            }
        }
        //pass object or only ID?
        public User GetUserById(User user)
        {
            User selUser = new User(user.UserId);
            var cnn = new MySqlConnection(connectionString);
            var cmd = new MySqlCommand("SELECT * FROM USER_DATA WHERE `ID`=@ID", cnn);
            cmd.Parameters.AddWithValue("@ID", user.UserId);
            cnn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                selUser = new User(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                    Convert.ToInt32(reader[4]), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString());
            cnn.Close();
            return selUser;
        }
        public User GetUserByUserName(User user)
        {
            User selUser = new User(user.UserId);
            var cnn = new MySqlConnection(connectionString);
            var cmd = new MySqlCommand("SELECT * FROM USER_DATA WHERE `UserName`=@UserName", cnn);
            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cnn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                selUser = new User(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                    Convert.ToInt32(reader[4]), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString());
            cnn.Close();
            return selUser;
        }
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            var cnn = new MySqlConnection(connectionString);
            var commandText = "SELECT * FROM user_data";
            using var cmd = new MySqlCommand(commandText, cnn);
            cnn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                users.Add(new User(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                    Convert.ToInt32(reader[4]), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString()));
            cnn.Close();
            return users;
        }
        public void DeleteUser(User user)
        {
            try
            {
                var conn = new MySqlConnection(connectionString);
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM `user_data` WHERE `ID` = @ID");
                cmd.Parameters.AddWithValue("@ID", user.UserId);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured:" + e.Message + "\t" + e.GetType());
            }
        }
        
        public void UpdateUser(User user)
        {
            string hashedPassword = PasswordHandler.HashPassword(user.Password);
            var conn = new MySqlConnection(connectionString);
            var commandText = "UPDATE user_data SET LastName=@LastName,FirstName=@FirstName,Email=@Email,UserLevel=@UserLevel,Password=@Password,TelephoneNumber=@TelephoneNumber,Address=@Address WHERE `ID`=@ID";
            using var cmd = new MySqlCommand(commandText, conn);
            conn.Open(); var reader = cmd.ExecuteReader();
            cmd.Parameters.AddWithValue("@ID", user.UserId);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@UserLevel", user.UserLevel);
            cmd.Parameters.AddWithValue("@Password", hashedPassword);
            cmd.Parameters.AddWithValue("@TelephoneNumber", user.TelephoneNumber);
            cmd.Parameters.AddWithValue("@Address", user.Address);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void WriteDetails(User.Details userDetails)
        {
            try
            {
                var conn = new MySqlConnection(connectionString);
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO user_details() VALUES(@,@)", conn);
                cmd.Parameters.AddWithValue("@ID", userDetails.UserId);
                cmd.Parameters.AddWithValue("@SecondaryTelephoneNumber", userDetails.SecondaryTelephoneNumber);
                cmd.Parameters.AddWithValue("@SecondaryAddress", userDetails.SecondaryAddress);
                cmd.Parameters.AddWithValue("@Profit", userDetails.Profit);
                cmd.Parameters.AddWithValue("@ItemsSold", userDetails.ItemsSold);
                cmd.Parameters.AddWithValue("@Bio", userDetails.Bio);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured:" + e.Message + "\t" + e.GetType());
            }
        }
        public User.Details GetDetails(User user)
        {
            User.Details selUser = new User.Details(user.UserId);
            var conn = new MySqlConnection(connectionString);
            var cmd = new MySqlCommand("SELECT * FROM user_details WHERE `ID`=@ID", conn);
            cmd.Parameters.AddWithValue("@ID", user.UserId);
            conn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                selUser = new User.Details(Convert.ToInt32(reader[0]), Convert.ToDateTime(reader[1]), Convert.ToInt32(reader[2]), reader[3].ToString(),
                    Convert.ToDecimal(reader[4]), Convert.ToInt32(reader[5]), reader[6].ToString());
            conn.Close();
            return selUser;
        }
        public void UpdateDetails(User.Details userDetails)
        {
            try
            {
                var conn = new MySqlConnection(connectionString);
                var commandText = "UPDATE user_details SET SecondaryTelephoneNumber = @SecondaryTelephoneNumber,SecondaryAddress=@SecondaryAddress,Profit=@Profit,ItemsSold=@ItemsSold,Bio=@Bio WHERE `ID`=@ID";
                using var cmd = new MySqlCommand(commandText, conn);
                conn.Open(); var reader = cmd.ExecuteReader();
                cmd.Parameters.AddWithValue("@ID", userDetails.UserId);
                cmd.Parameters.AddWithValue("@SecondaryTelephoneNumber", userDetails.SecondaryTelephoneNumber);
                cmd.Parameters.AddWithValue("@SecondaryAddress", userDetails.SecondaryAddress);
                cmd.Parameters.AddWithValue("@Profit", userDetails.Profit);
                cmd.Parameters.AddWithValue("@ItemsSold", userDetails.ItemsSold);
                cmd.Parameters.AddWithValue("@Bio", userDetails.Bio);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured:" + e.Message + "\t" + e.GetType());
            }
        }
        public void DeleteDetails(User.Details userDetails)
        {
            try
            {
                var conn = new MySqlConnection(connectionString);
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM details_data WHERE `ID`=@ID");
                cmd.Parameters.AddWithValue("@ID", userDetails.UserId);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception occured:" + e.Message + "\t" + e.GetType());
            }
        }
    }
}
