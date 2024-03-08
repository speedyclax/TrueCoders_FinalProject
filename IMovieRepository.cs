using System;
using System.Collections.Generic;
using TrueCoders_Final_Project_MVC.Models;

namespace TrueCoders_Final_Project_MVC
{
    public interface IMovieRepository
    {
        public IEnumerable<Movie> GetAllMovies();
        public Movie GetMovie(int id);
        public void UpdateMovie(Movie prod);
        public void InsertMovie(Movie movieToInsert);
        public void DeleteMovie(Movie movie);

    }
}
