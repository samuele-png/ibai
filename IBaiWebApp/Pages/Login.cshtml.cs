using IBaiWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IBaiWebApp.Pages;

public class LoginModel : PageModel
{
    public const string SessionKeyUserName = "_UserName";
    public const string SessionKeyPassword = "_Password";
    public const string SessionKeyUserId = "_UserId";
    private readonly ILogger<IndexModel> _logger;
    public LoginModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        PageTitle = "Login form";
    }
    public string PageTitle { get; private set; }
    [BindProperty] public new UserModel User { get; set; }
    public IActionResult OnGet()
    {
        if (HttpContext.Session.GetString(SessionKeyUserName) != null && HttpContext.Session.GetString(SessionKeyUserName) == User.UserName)
        {
            return new RedirectToPageResult("/Index");
        }
        return Page();
    }

    // interface that xecutes the result operation of the action method asynchronously
    // returns asynchronous methods
    // needed because 2 return paths are needed
    public IActionResult OnPost()
    {
        ModelState.Remove("User.Email");
        ModelState.Remove("User.TelephoneNumber");
        ModelState.Remove("User.Address");
        ModelState.Remove("User.FirstName");
        ModelState.Remove("User.LastName");
        var errors = ModelState.Values.SelectMany(v => v.Errors);
        if (ModelState.IsValid)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyUserName)))
            {
                if (User.CheckCredentials(User.UserName, User.Password) == true)
                {
                    HttpContext.Session.SetString(SessionKeyUserName, User.UserName);
                }
                else
                {
                    return RedirectToPage("/Error");
                }
            }
            var name = HttpContext.Session.GetString(SessionKeyUserName);
            return RedirectToPage("/Index", name);
        }
        return RedirectToPage("/Login");
    }
}