using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce2.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce2.Areas.Admin.Controllers
{
    [Area("Admin")]
   //[Route("Admin/Home")]
    public class HomeController : BaseController
    {
        public HomeController(IHttpContextAccessor accessor) : base(accessor)
        {
           
        }

        public IActionResult IndexMain()
        {
            return View();
        }
    }
}