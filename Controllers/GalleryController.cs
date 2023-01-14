using Microsoft.AspNetCore.Mvc;

namespace ILibrary.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Carousel()
        {
            return View();
        }
    }
}
