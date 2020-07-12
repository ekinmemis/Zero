using Zero.Core.Domain.Users;

namespace Zero.Service.Authentication
{
    public interface IAuthenticationService
    {
        void SignIn(ApplicationUser applicationUser, bool rememberMe);

        void SignOut();

        ApplicationUser GetAuthenticatedApplicationUser();
    }
}
