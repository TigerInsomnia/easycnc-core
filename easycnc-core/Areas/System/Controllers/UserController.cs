using easycnc_core.Areas.System.Request;
using easycnc_core.Areas.System.Interface;
using easycnc_core.Attribute;

using Microsoft.AspNetCore.Mvc;

namespace easycnc_core.Areas.System.Controllers
{
    [Area("system")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [OperateLog("查询员工列表")]
        public IActionResult FindAll(UserRequest userRequest)
        {
            return Json(_userService.FindAll(userRequest));
        }
    }
}
