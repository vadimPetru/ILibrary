using Microsoft.AspNetCore.Mvc;

namespace ILibrary.Controllers
{
    public class MainController : Controller
    {
        public IActionResult MainContent()
        {
            return View();
        }

    }
}
