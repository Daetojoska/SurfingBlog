using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurfClub.Controllers
{
    public class RegistrController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
