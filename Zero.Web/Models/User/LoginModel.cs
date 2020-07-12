using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zero.Web.Models.User
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}