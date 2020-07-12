using System.Web.Mvc;
using Zero.Core.Domain.Users;
using Zero.Service.Authentication;
using Zero.Service.Users;
using Zero.Web.Models.User;

namespace Zero.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IAuthenticationService _formsAuthenticationService;
        private readonly IApplicationUserService _applicationUserService;


        public UserController()
        {
            _formsAuthenticationService = new FormsAuthenticationService();
            _applicationUserService = new ApplicationUserService();
        }


        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _applicationUserService.GetApplicationUserByEmail(model.Email);

                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                    return View();
                }

                if (user.Password != model.Password)
                {
                    ModelState.AddModelError("", "Şifrenizi kontrol ediniz.");
                    return View();
                }

                _formsAuthenticationService.SignIn(user, model.RememberMe);

                return Redirect("/");
            }

            return View();
        }

        public ActionResult Logout()
        {
            _formsAuthenticationService.SignOut();

            return Redirect("/");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    Id = model.Id,
                    TurkishIdentityNumber = model.TurkishIdentityNumber,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Password = model.Password,
                    DateOfBirth = model.DateOfBirth,
                    PalceOfBirth = model.PalceOfBirth,
                };

                _applicationUserService.InsertApplicationUser(applicationUser);

                return Redirect("/");
            }

            return View(model);
        }
    }
}