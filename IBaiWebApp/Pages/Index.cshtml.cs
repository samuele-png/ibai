using IBaiWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using Domain_Layer.Classes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using DataLayer;
using Domain_Layer.ClassManagers;
using Domain_Layer.Classes;
namespace IBaiWebApp.Pages
{
    public class IndexModel : PageModel
    {
        ProductManager productManager = new ProductManager(new ProductData());
    
        [BindProperty] public new ProductModel selProduct { get; set; }
        public void OnGet()
        {
         
        }
        public IActionResult OnPostPassProduct(int productID)
        {
            return  RedirectToPage("/ProductPage?ID=" + productID);

        }
    }
}