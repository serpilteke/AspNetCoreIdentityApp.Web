using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityApp.Web.ViewModel
{
    public class SignUpViewModel
    {
        public SignUpViewModel() { }

        public SignUpViewModel(string userName, string email, string password, string phone)
        {
            UserName = userName;
            Email = email;
            Password = password;
            PasswordConfirm = password;

            Phone = phone;
        }

        [Display(Name = "User Name: ")]
        public string UserName { get; set; }
        
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Display(Name = "Password: ")]
        public string Password { get; set; }

        [Display(Name = "Password Confirm: ")]
        public string PasswordConfirm { get; set; }

        [Display(Name = "Phone: ")]
        public string Phone { get; set; }

    }
}
