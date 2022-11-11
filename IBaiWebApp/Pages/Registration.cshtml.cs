using Domain_Layer.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IBaiWebApp.Models;
using Domain_Layer.ClassManagers;
using DataLayer;

namespace IBaiWebApp.Pages;

public class RegisterModel : PageModel
{
    public RegisterModel()
    {
        PageTitle = "Register Form";
    }
    
    public string PageTitle { get; private set; }
    [BindProperty] public new UserModel User { get; set; }
    public void OnGet()
    {
    }
    public void OnPost()
    {
        IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
        if (ModelState.IsValid)
        {
            UserManager usm = new(new UserData());
            User newUser = new User(0, User.LastName, User.FirstName, User.Email, User.UserLevel, User.UserName, User.Password, User.Address, User.TelephoneNumber);
            usm.WriteUser(newUser);
            RedirectToPage("/Index");
        }
    }
}
