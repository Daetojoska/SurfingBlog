using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestProject1.Models;

namespace TestProject1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyAppDBContext dbContext;
        public HomeController(ILogger<HomeController> logger,MyAppDBContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {

            ViewBag.Count = 9;
            ViewBag.Message = "Приветствую смотрящих";
            ViewBag.Date = DateTime.Now;
            ViewBag.Names = new[] { "Арсений", "Даниил", "Вован" };
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.Group = dbContext.Students.ToList();
            return View();

        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Student()
        {
            
         var StudentModel = dbContext.Students.FirstOrDefault(c => c.Age > 30);
            if (StudentModel != null)
            {
                return View(StudentModel);
            }
            else
            {   return
                View("Error", new ErrorViewModel { });
                
            }

        }



            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
