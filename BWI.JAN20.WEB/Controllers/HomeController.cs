using BWI.JAN20.WEB.Filters;
using BWI.JAN20.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BWI.JAN20.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //[ServiceFilter(typeof(MyActionFilter))]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous] 
        public IActionResult Contact()
        {


            ViewData["name"] = "Binod Sapkota";
            ViewBag.Message = "Your are viewing Contact Information.";
            string[] students = {"Binod","Brijesh","Madhyam","Asish","Dip","Shashank" };
            ViewData["Students"]=students;

            ContactMeModel model = new ContactMeModel()
            {

                Address = "Tokha, Kathmandu",
                Email = "binod@gmail.com",
                Phone = "+977-985124587",
                WebAddress = "http://www.sth.com"
            };
            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AboutUs()
        {
            return View();
        }
    }
}