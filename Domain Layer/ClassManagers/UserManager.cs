using Domain_Layer.Classes;
using Domain_Layer.Interfaces;

namespace Domain_Layer.ClassManagers
{
    public class UserManager
    {//take interface and inject it into the constructor of the manager
        Interfaces.IUserData _UserData;
        public UserManager(IUserData userData)
        {
            _UserData = userData;
        }
        public void WriteUser(User user)
        {
            _UserData.WriteUser(user);
        }
        public List<User> GetUsers()
        {
            return _UserData.GetUsers();
        }
        public User GetUserById(User user)
        {
            return _UserData.GetUserById(user);
        }
        public User GetUserByUserName(User user)
        {
            return _UserData.GetUserByUserName(user);
        }
        public void DeleteUser(User user)
        {
            _UserData.DeleteUser(user);
        }
        public void UpdateUser(User user)
        {
            _UserData.UpdateUser(user);
        }
        public void WriteDetails(User.Details userDetails)
        {
            _UserData.WriteDetails(userDetails);
        }
        public User.Details GetDetails(User user)
        {
            return _UserData.GetDetails(user);
        }
        public void UpdateDetails(User.Details userDetails)
        {
            _UserData.UpdateDetails(userDetails);
        }
        public void DeleteDetails(User.Details userDetails)
        {
            _UserData.DeleteDetails(userDetails);
        }
    }
}
