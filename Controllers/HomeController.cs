using HelloASPDotNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HelloASPDotNET.Controllers
{
    //[Route("/helloworld")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[Route("/helloworld/welcome")]
        [HttpGet]
        public IActionResult Index()
        {
            //return View();
            return Content("<form action='/home/welcome/' method='post'>" +
    "<input type='text' name='name' />" +
    "<select name='language'>" +
    "<option value='en'>English</option>" +
    "<option value='fr'>French</option>" +
    "<option value='sp'>Spanish</option>" +
    "<option value='gr'>German</option>" +
    "<option value='it'>Italian</option>" +
    "<option value='po'>Portuguese</option>" +
    "</select>" +
    "<input type='submit' value='Greet me!' />" +
    "</form>", "text/html");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // GET: /<controller>/welcome
        //[Route("/helloworld/welcome/{name}/{language}")
        [HttpPost]
        public IActionResult Welcome(string name, string language)
        {
            return Content("<h1> " + CreateMessage(name, language), "text/html");
        }

        public static string CreateMessage(string name, string language)
        {
            switch (language)
            {
                case "en":
                    return "Hello " + name;
                case "fr":
                    return "BONJOUR " + name;
                case "sp":
                    return "HOLA " + name;
                case "gr":
                    return "HALLO " + name;
                case "it":
                    return "CIAO " + name;
                case "po":
                    return "OLÀ " + name;
                default:
                    return "Hello " + name;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
