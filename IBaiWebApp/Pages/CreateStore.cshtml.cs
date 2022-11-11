using DataLayer;
using Domain_Layer.Classes;
using Domain_Layer.ClassManagers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain_Layer.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IBaiWebApp.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class CreateStoreModel : PageModel
    {
        public CreateStoreModel()
        {
            PageTitle = "New Store Form";
        }

        public string PageTitle { get; private set; }

        [BindProperty] public new Models.StoreModel NewStore { get; set; }
        StoreManager storeManager = new StoreManager(new StoreData());
        UserManager userManager = new UserManager(new UserData());
        
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            // string? userName = HttpContext.Session.GetString("_UserName");
            // User selUser = userManager.GetUserByUserName(new User(0,userName));
            string userName = HttpContext.Session.GetString("_UserName");
            List<Categories> categories = new();
            ModelState.Remove("NewStore.Products");
            ModelState.Remove("NewStore.Owner");
            IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
             
            if (ModelState.IsValid)
            {
                User seluser = userManager.GetUserByUserName(new User(0, userName));
                Store newStore = new Store(0, seluser, NewStore.StoreName,NewStore.Description, NewStore.Categories);
                // to be fixed
                Store storeId = storeManager.GetStoreByName(new Store(NewStore.StoreName));
                storeManager.WriteStore(newStore);
                return RedirectToPage("/StorePage",storeId.StoreId);
            }
            return Page();
        }
    }
}
