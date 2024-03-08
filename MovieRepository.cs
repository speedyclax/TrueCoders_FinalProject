using Dapper;
using System.Data;
using TrueCoders_Final_Project_MVC.Models;

namespace TrueCoders_Final_Project_MVC
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IDbConnection _conn;

        public MovieRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _conn.Query<Movie>("SELECT * FROM movies;");
        }
        public void UpdateMovie(Movie movie)
        {
            _conn.Execute("UPDATE movies SET Title = @title, Rating = @rating WHERE id_movie = @id_movie",
             new { title = movie.Title, rating = movie.Rating, id_movie = movie.id_movie });
        }

        public Movie GetMovie(int id)
        {
            return _conn.QuerySingle<Movie>("SELECT * FROM movies WHERE id_movie = @id", new { id = id });
        }

        public void InsertMovie(Movie movieToInsert)
        {
            _conn.Execute("INSERT INTO movies (Title, Rating, Year_Reviewed) VALUES (@title, @rating, @year_reviewed);",
                    new { title = movieToInsert.Title, rating = movieToInsert.Rating, year_reviewed = movieToInsert.year_reviewed });
        }

        public void DeleteMovie(Movie movie)
        {
            _conn.Execute("DELETE FROM Movies WHERE id_movie = @id;", new { id = movie.id_movie });
        }



    }
}
