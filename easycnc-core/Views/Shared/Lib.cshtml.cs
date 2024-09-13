using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace easycnc_core.Views.Shared
{
    public class Lib : PageModel
    {
        private readonly ILogger<Lib> _logger;

        public Lib(ILogger<Lib> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}