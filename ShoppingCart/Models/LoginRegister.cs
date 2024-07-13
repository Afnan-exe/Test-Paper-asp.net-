using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ShoppingCart.Models
{
    public class LoginRegister
    {
        [Key]
        public int LoginRegisterId { get; set; }

        [DisplayName("User Name")]
        [MinLength(3 , ErrorMessage ="User Name Must Contain 3 Characters")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Password")]
        [MaxLength(25 , ErrorMessage ="Password Must Be Smaller Than 25 Characters") , MinLength(7,ErrorMessage = "Password Must Contain 7 Characters")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [MaxLength(25, ErrorMessage = "Password Must Be Smaller Than 25 Characters"), MinLength(7, ErrorMessage = "Password Must Contain 7 Characters")]
        public string PasswordConfirmed { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone No")]
        [MinLength(11 , ErrorMessage = "Phone Number Must Contain 14 Characters")]
        public string Phone { get; set; }

        [MinLength(5 , ErrorMessage ="Address Must Contain 5 Characters")]
        [DisplayName("Delivery Address")]
        public string Address { get; set; }
    }
}
