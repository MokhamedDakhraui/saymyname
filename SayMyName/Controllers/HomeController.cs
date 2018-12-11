using Microsoft.AspNetCore.Mvc;
using SayMyName.Models;
using System.Diagnostics;

namespace SayMyName.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Say()
        {
            ViewData["Name"] = Request.Cookies.TryGetValue("name", out string name) ? name : "no name";

            return View();
        }

        public IActionResult Set()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Set(string name)
        {
            Response.Cookies.Append("name", name);

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
