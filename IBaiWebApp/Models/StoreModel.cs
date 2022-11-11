 using Domain_Layer.Classes;
using Domain_Layer.Enums;
using System.ComponentModel.DataAnnotations;

namespace IBaiWebApp.Models
{
    public class StoreModel
    {
        public int StoreId { get; set; }
        public User Owner { get; set; }
        public List<Product> Products { get; set; }
        [Required(ErrorMessage = "Store name is required")]
        [StringLength(15, ErrorMessage = "Please do not enter values over 15 characters")]
        public string StoreName { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
        public string Description { get; set; }
        public List<Categories> Categories { get; set; }

    }
}