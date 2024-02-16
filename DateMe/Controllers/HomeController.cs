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
            return View("MovieApplication");
        }

        public IActionResult GetToKnow()
        {
            return View("GetToKnow");
        }

        [HttpPost]
        public IActionResult MovieApplication(MovieApp response)
        {
            _context.MovieApp.Add(response);    // Add record to database
            _context.SaveChanges(); 
            
            return View("Confirmation", response);
        }
    }
}
