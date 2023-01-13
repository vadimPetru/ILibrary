using DataBase.DAL.Context;
using DataBase.DAL.Entities;
using ILibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ILibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IlibraryContext _db;

        public HomeController(ILogger<HomeController> logger , IlibraryContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
           
            return View();
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
    }
}