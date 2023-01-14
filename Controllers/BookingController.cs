using DataBase.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ILibrary.Controllers
{
    public class BookingController : Controller
    {
        private ManagerDB _manager;
        public BookingController()
        {
            _manager = new ManagerDB();
        }

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetBooking(string? BookCode, string? ReaderCode, DateTime date)
        {
            Booking book = new Booking();
            try
            {
                 book = _manager.FindBooking(BookCode, ReaderCode, date);
                if (book == null)
                {
                    BadRequest("Нету такой книги");
                }
            }
            catch
            {
                Form();
            }//TODO:

            return View("GetBooking", book);
        }
    }
}
