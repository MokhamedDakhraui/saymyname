using Microsoft.AspNetCore.Mvc;
using SayMyName.Contracts;
using SayMyName.Models;
using System.Diagnostics;

namespace SayMyName.Controllers
{
    public class HomeController : Controller
    {
        public INameRepository NameRepository { get; }

        public HomeController(INameRepository nameRepository)
        {
            this.NameRepository = nameRepository;
        }

        public IActionResult Say()
        {
            ViewData["Name"] = this.NameRepository.GetName() ?? "no name";

            return View();
        }

        public IActionResult Set()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Set(string name)
        {
            this.NameRepository.SetName(name);

            return RedirectToAction(nameof(Say));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
