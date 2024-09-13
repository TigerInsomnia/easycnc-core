using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace easycnc_core.Attribute
{
    public class OperateLogAttribute : ActionFilterAttribute
    {
        private readonly string _msg;

        public OperateLogAttribute(string msg)
        {
            _msg = msg;
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine(_msg);
        }
    }
}