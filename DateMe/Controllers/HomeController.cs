using MovieDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MovieDB.Controllers
{
    public class HomeController : Controller
    {
        private MovieApplicationContext _context;

        public HomeController(MovieApplicationContext temp) // Constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieApplication()
        {
            ViewBag.Title = _context.Category.ToList();

            return View("MovieApplication", new MovieApp());
        }

        public IActionResult GetToKnow()
        {
            return View("GetToKnow");
        }

        [HttpPost]
        public IActionResult MovieApplication(MovieApp response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);    // Add record to database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else // invalid data
            {
                ViewBag.Title = _context.Category.ToList();

                return View(response);
            }
        }

        public IActionResult MovieList()
        {
            // Linq connect 
            var movies = _context.Movies
                .OrderBy(x => x.Title).ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Title = _context.Category.OrderBy(x => x.CategoryName).ToList();

            return View("MovieApplication", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(MovieApp updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(MovieApp application) 
        {
            _context.Movies.Remove(application);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
