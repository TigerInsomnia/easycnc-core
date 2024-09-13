using easycnc_core.Areas.System.Models;

namespace easycnc_core.Areas.Auth.Interface
{
    public interface IAuthService
    {

        User? VerifyUser(string username,string password);
    }
}
