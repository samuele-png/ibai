using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain_Layer.Classes;
using Domain_Layer.ClassManagers;
using DataLayer;
using IBaiWebApp.Models;

namespace IBaiWebApp.Pages
{
    public class ProductPageModel : PageModel
    {
   
        public Product product;
        public void OnGet(int productId)
        {
            ViewData["ID"] = productId;
        }
    }
}
