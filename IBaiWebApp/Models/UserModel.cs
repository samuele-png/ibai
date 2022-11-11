using Domain_Layer.Classes;
using Domain_Layer.ClassManagers;
using DataLayer;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace IBaiWebApp.Models
{

    public class UserModel
    {
        public int UserLevel { get; set; }
        public int OwnedStoreId { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(15, ErrorMessage = "Please do not enter values over 15 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [StringLength(15, ErrorMessage = "Please do not enter values over 15 characters")]
        public string FirstName { get; set; }
        //copied from generator, learning arabic is easier than regex
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Your Email is not valid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [StringLength(15, ErrorMessage = "Please do not enter values over 15 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        // regex doesn't work
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Minimum eight characters, at least one uppercase letter, one lowercase letter and one number:")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Address is required")] public string Address { get; set; }
        [Required(ErrorMessage = "Mobile no. is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string TelephoneNumber { get; set; }
        UserManager usM = new UserManager(new UserData());
        public bool CheckCredentials(string userName, string password)
        {
            
            List<User> userList = new List<User>(usM.GetUsers());
            User userToCheck; 
            try
            {
                userToCheck = userList.Find(x => x.UserName == userName);
                if (userToCheck != null && PasswordHandler.ValidatePassword(password, userToCheck.Password) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
