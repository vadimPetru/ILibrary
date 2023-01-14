using Microsoft.AspNetCore.Mvc;

namespace ILibrary.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult FormRegistration()
        {
            return View();
        }
    }
}
