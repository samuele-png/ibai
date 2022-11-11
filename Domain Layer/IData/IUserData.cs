using Domain_Layer.Classes;

namespace Domain_Layer.Interfaces
{
    public interface IUserData
    {
        //interface used for DI
        List<User> GetUsers();
        User GetUserById(User user);
        User GetUserByUserName(User user);
        void WriteUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
        void WriteDetails(User.Details userDetails);
        User.Details GetDetails(User user);
        void UpdateDetails(User.Details userDetails);
        void DeleteDetails(User.Details userDetails);
    }


}

