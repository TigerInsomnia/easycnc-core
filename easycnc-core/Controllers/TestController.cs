using easycnc_core.Areas.System.Interface;
using easycnc_core.Areas.System.Models;
using easycnc_core.Data;
using easycnc_core.Workflow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WorkflowCore.Interface;
using WorkflowCore.Persistence.EntityFramework.Interfaces;
using WorkflowCore.Persistence.EntityFramework.Models;
using WorkflowCore.Persistence.EntityFramework.Services;
using WorkflowCore.Persistence.PostgreSQL;

namespace easycnc_core.Controllers
{
    public class TestController : Controller
    {

        private IServiceProvider serviceProvider;
        public TestController(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
       

        public IActionResult Index()
        {

            
            return Json("hello world");
        }
    }
}
