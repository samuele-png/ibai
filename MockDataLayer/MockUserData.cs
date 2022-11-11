using Domain_Layer.Classes;
using Domain_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDataLayer
{
    public class MockUserData : IUserData
    {
        public void DeleteDetails(User.Details userDetails)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public User.Details GetDetails(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUserName(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void UpdateDetails(User.Details userDetails)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void WriteDetails(User.Details userDetails)
        {
            throw new NotImplementedException();
        }

        public void WriteUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
