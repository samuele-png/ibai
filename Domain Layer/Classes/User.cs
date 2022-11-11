using Domain_Layer.Enums;
using Domain_Layer.Interfaces;

namespace Domain_Layer.Classes
{
    public class User : ISetUserLevel
    {   
        public User() { }
       
        public User(int userId)
        {
            UserId = userId;
        }
        
        public User(int userId,string userName)
        {
            UserId = userId;
            UserName = userName;
        }
        public User(int userId, string lastName, string firstName, string email, int userLevel, string userName,
            string password, string address, string telephoneNumber)
        {
            UserId = userId;
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            UserLevel = userLevel;
            UserName = userName;
            Password = password;
            Address = address;
            TelephoneNumber = telephoneNumber;
        }

        public int UserId { get; private set; }
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string Email { get; private set; }
        public int UserLevel { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Address { get; private set; }
        public string TelephoneNumber { get; private set; }
        public bool Online { get; private set; }
        void ISetUserLevel.SetAsAdmin()
        {
            UserLevel = (int)UserLevels.ADMIN;
        }
        void ISetUserLevel.SetAsStandard()
        {
            UserLevel = (int)UserLevels.STANDARD;
        }
        void ISetUserLevel.SetAsPremium()
        {
            UserLevel = (int)UserLevels.PREMIUM;
        }
        void ISetUserLevel.SetAsSeller()
        {
            UserLevel = (int)UserLevels.SELLER;
        }
        void ISetUserLevel.SetAsPremiumSeller()
        {
            UserLevel = (int)UserLevels.PREMIUMSELLER;
        }
        public class Details : User
        {
            public Details(int userId)
            {
                base.UserId = userId;
            }
            public Details(int userId, DateTime dateOfBirth, int secondaryTelephoneNumber, string secondaryAddress, decimal profit, int itemsSold, string? bio)
            {
                base.UserId = userId;
                DateOfBirth = dateOfBirth;
                SecondaryAddress = secondaryAddress;
                SecondaryTelephoneNumber = secondaryTelephoneNumber;
                Profit = profit;
                ItemsSold = itemsSold;
                Bio = bio;
            }
            public DateTime DateOfBirth { get; private set; }
            public string SecondaryAddress { get; private set; }
            public int SecondaryTelephoneNumber { get; private set; }
            public decimal Profit { get; private set; }
            public int ItemsSold { get; private set; }
            public string? Bio { get; private set; }

        }


    }
}