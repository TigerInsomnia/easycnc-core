using easycnc_core.Areas.System.Interface;
using Microsoft.AspNetCore.Mvc;

namespace easycnc_core.Areas.System.Controllers
{
    [Area("system")]
    public class DeptController : Controller
    {
        private readonly IDeptService deptService;
        public DeptController(IDeptService deptService)
        {
            this.deptService = deptService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetDeptTree()
        {
            return Json(deptService.GetDeptTree());
        }
    }
}
