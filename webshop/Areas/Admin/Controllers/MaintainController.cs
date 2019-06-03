using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Mantain")]
    public class MaintainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}