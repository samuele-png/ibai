using Domain_Layer.Classes;
using IBaiWebApp.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain_Layer.Enums;
using Domain_Layer.ClassManagers;
using DataLayer;
namespace IBaiWebApp.Pages
{
   

    public class ProductCreationModel : PageModel
    {
        public ProductCreationModel()
        {
            PageTitle = "Create Product Form";
        }

        public string PageTitle { get; private set; }
        [BindProperty] public new ProductModel NewProduct { get; set; }
        int storeId;
        public void OnGet(int storeID)
        {
            ViewData["StoreID"] = storeID;
            storeId = storeID;
        }
        public void OnPost()
        {
            ModelState.Remove("NewProduct.ProductID");
            ModelState.Remove("NewProduct.Store");

            IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                ProductManager usm = new(new ProductData());
                Product newProduct = new Product(0, NewProduct.Name, NewProduct.Description, NewProduct.Price, NewProduct.ShippingFee, NewProduct.PictureUrl, NewProduct.Categories, new Store(NewProduct.StoreId));
                usm.WriteProduct(newProduct);
                int storeId = newProduct.Store.StoreId;
                RedirectToPage("/Success",storeId);
            }
            
        }
    }
}
