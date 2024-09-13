using easycnc_core.Areas.Auth.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace easycnc_core.Areas.Auth.Controllers
{
    [Area("auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  PostLoginAsync(string username,string password)
        {
            var user =_authService.VerifyUser(username, password);
            if (user == null)
            {
                return Json(new { code = 500, msg = "无此用户" });
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.Username),
                    new Claim("Realname",user.Realname)
                };
            }
            return Ok();
        }
    }
}
