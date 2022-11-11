using Domain_Layer.ClassManagers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataLayer;
using Domain_Layer.Classes;
using Domain_Layer.Enums;

namespace IBaiWebApp.Pages
{
    public class ProfilePageModel : PageModel
    {
        [BindProperty] public IBaiWebApp.Models.StoreModel Store { get; set; }
        [BindProperty] public IBaiWebApp.Models.UserModel User { get; set; }
        string  newUserName = String.Empty; 
        UserManager usr = new(new UserData());

        //would like not use empty constructor here but couldn't figure out how to make it work without
        User selUser = new();
        public void OnGet(string? name)
        {
            newUserName = name;
            selUser= usr.GetUserByUserName(new User(0, newUserName));
        }
        public void OnPostSetUserLevel()
        {
            selUser = usr.GetUserByUserName(new User(0, User.UserName));
            usr.UpdateUser(new User(selUser.UserId, selUser.LastName, selUser.FirstName, selUser.Email, User.UserLevel, selUser.UserName, selUser.Password, selUser.Address, selUser.TelephoneNumber));
        }
        public void OnPostChangeEmail()
        {
            usr.UpdateUser(new User(selUser.UserId, selUser.LastName, selUser.FirstName, User.Email, selUser.UserLevel, selUser.UserName, selUser.Password, selUser.Address, selUser.TelephoneNumber));
        }
    }
}
