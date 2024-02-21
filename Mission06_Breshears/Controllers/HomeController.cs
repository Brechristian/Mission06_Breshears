using Microsoft.AspNetCore.Mvc;
using Mission06_Breshears.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("AddMovie", new AddMovie());
        }

        [HttpPost]
        public IActionResult Confirmation(AddMovie response)
        {
            if (ModelState.IsValid)
            {
                _context.AddMovie.Add(response); //Add record to database
                _context.SaveChanges();
                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult SeeMovies()
        {
            var seeMovies = _context.AddMovie
                .OrderBy(x => x.Title) 
                .ToList();

            return View(seeMovies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.AddMovie
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

            return View("AddMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(AddMovie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("SeeMovies");
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.AddMovie
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(AddMovie addMovie)
        {
            _context.AddMovie.Remove(addMovie);
            _context.SaveChanges();

            return RedirectToAction("SeeMovies");
        }



    }
}
