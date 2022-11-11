using Domain_Layer.Classes;
using Domain_Layer.Enums;
using System.ComponentModel.DataAnnotations;

namespace IBaiWebApp.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [RegularExpression("^(?!0\\.00)\\d{1,3}(,\\d{3})*(\\.\\d\\d)?$", ErrorMessage = "Please enter valid price")]

        public double? Price { get; set; }
        [Required(ErrorMessage = "Shipping is required")]
        [RegularExpression("^(?!0\\.00)\\d{1,3}(,\\d{3})*(\\.\\d\\d)?$", ErrorMessage = "Please enter valid fee")]
        public double? ShippingFee { get; set; }
        public int StoreId { get; set; }
        [Required(ErrorMessage = "Categories are required")]
        public List<Categories> Categories { get; set; }

        public string PictureUrl { get;  set; }
    }
}
