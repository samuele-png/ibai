using Domain_Layer.Classes;
using Domain_Layer.Enums;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace Unit_Test
{
    [TestClass]
    public class DataUnitTest
    {
        [TestMethod]
        public void TestThatUsersAreEqual()
        {
            User user1 = new User(20,"lastName","firstName","email",0,"userName","password","address","telephoneNumber");
            User user2 = new User(20, "lastName", "firstName", "email", 0, "userName", "password", "address", "telephoneNumber");
            Assert.AreEqual(user1.UserId, user2.UserId);
            Assert.AreEqual(user1.FirstName, user2.FirstName);
            Assert.AreEqual(user1.LastName, user2.LastName);
            Assert.AreEqual(user1.Email, user2.Email);
            Assert.AreEqual(user1.UserName, user2.UserName);
            Assert.AreEqual(user1.Password, user2.Password);
            Assert.AreEqual(user1.Address, user2.Address);
            Assert.AreEqual(user1.UserLevel, user2.UserLevel);
        }
        public void TestThatStoresAreEqual()
        {
            List<Categories> catList = new();
            catList.Add(Categories.Crafts); 
            catList.Add(Categories.Antiques);
            Store store1 = new Store(44, new User(18), "storeName", "description", catList);
            Store store2 = new Store(44, new User(18), "storeName", "description", catList);
            Assert.AreEqual(store1.StoreId, store2.StoreId);
            Assert.AreEqual(store1.Owner.UserId, store2.Owner.UserId);
            Assert.AreEqual(store1.StoreName,store2.StoreName);
            Assert.AreEqual(store1.Description, store2.Description);
            Assert.AreEqual(store1.Categories, store2.Categories);
        }

    }
}