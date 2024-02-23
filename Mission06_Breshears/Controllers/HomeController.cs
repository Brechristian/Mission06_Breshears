using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult AddMovie(AddMovie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); //Add record to database
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
            var seeMovies = _context.Movies
                .OrderBy(x => x.Title)
                .ToList();

            return View(seeMovies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var recordToEdit = _context.Movies
                    .SingleOrDefault(x => x.MovieId == id);

                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View("AddMovie", recordToEdit);
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Error editing movie with ID {id}: {ex.Message}");
                throw; // rethrow the exception for debugging purposes
            }
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
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(AddMovie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("SeeMovies");
        }



    }
}
