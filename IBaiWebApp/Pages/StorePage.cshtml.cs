using Domain_Layer.Classes;
using Domain_Layer.ClassManagers;
using IBaiWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataLayer;

namespace IBaiWebApp.Pages
{
    public class StorePageModel : PageModel
    {
        StoreManager storeManager = new(new StoreData());
        UserManager userManager = new(new UserData());
        [BindProperty] public StoreModel SelectedStore { get; set; }
        StoreModel selStore = new();

        public void OnGet(int storeId)
        {
            ViewData["StoreId"] = storeId;
        }
    }
}
