using BWI.JAN20.WEB.ValidationFilter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BWI.JAN20.WEB.Models
{
    [Table("USERS")]
    public class SignupModel
    {
        public int Id { get; set; }
        public string Email { get; set; }

#if DEBUG == false
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")]
#endif
        [MyCustomValidation]
        public string Password { get; set; }
        [Compare("Password")]

        public string ConfirmPassword { get; set; }
        public string ImageUrl { get; set; }

    }

    public class LoginModel
    {
        [EmailAddress]

        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
