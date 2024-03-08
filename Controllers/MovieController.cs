using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrueCoders_Final_Project_MVC.Models;

namespace TrueCoders_Final_Project_MVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository repo;

        public MovieController(IMovieRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var movies = repo.GetAllMovies();
            return View(movies);
        }

        public IActionResult ViewMovie(int id)
        {
            var movie = repo.GetMovie(id);
            return View(movie);
        }

        public IActionResult UpdateMovie(int id)
        {
            Movie prod = repo.GetMovie(id);
            if (prod == null)
            {
                return View("MovieNotFound");
            }
            return View(prod);
        }
        public IActionResult UpdateMovieToDatabase(Movie movie)
        {
            repo.UpdateMovie(movie);

            return RedirectToAction("ViewMovie", new { id = movie.id_movie });
        }
        public IActionResult InsertMovie(Movie movieToInsert)
        {
            return View(movieToInsert);
        }
        public IActionResult InsertMovieToDatabase(Movie movieToInsert)
        {
            repo.InsertMovie(movieToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteMovie(Movie movie)
        {
            repo.DeleteMovie(movie);
            return RedirectToAction("Index");
        }
    }

}
