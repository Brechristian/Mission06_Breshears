using Microsoft.AspNetCore.Mvc;
using Mission06_Breshears.Models;
using System.Diagnostics;

namespace Mission06_Breshears.Controllers
{
    public class HomeController : Controller
    {
        private AddMovieContext _context;

        public HomeController(AddMovieContext temp) //Constructor
        {
            _context = temp;
        }

         public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View("AddMovie");
        }

        [HttpPost]
        public IActionResult Confirmation(AddMovie response)
        {
            _context.AddMovie.Add(response); //Add record to database
            _context.SaveChanges();
            return View("Confirmation", response);
        }
    }
}
