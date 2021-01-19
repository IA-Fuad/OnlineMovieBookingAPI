using OnlineMovieBookingAPI.Data;
using OnlineMovieBookingAPI.Models.EntityModels;
using OnlineMovieBookingAPI.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace OnlineMovieBookingAPI.ControllerServices
{
    public interface IMovieServices
    {
        List<MovieResponse> GetAllMovies(int? cinemaId);
        List<MovieResponse> GetAllMoviesInTimeRange(DateTime start, DateTime end);
        MovieResponse GetMovie(int id);
        List<MoviePerCinemaResponse> GetDistinctMoviePerCinema();
        MovieResponse SaveMovie(MovieEntity movieResponse);
        bool DeleteMovie(int id);
    }

    public class MovieServices : IMovieServices
    {
        private readonly OnlineMovieBookingContext db;

        public MovieServices(OnlineMovieBookingContext context)
        {
            db = context;
        }

        public List<MovieResponse> GetAllMovies(int? cinemaId)
        {
            List<MovieEntity> movieEntities;

            if (cinemaId != null)
            {
                if (db.Halls.FirstOrDefault(h => h.CinemaId == cinemaId) == null)
                {
                    return null;
                }

                movieEntities = db.Halls.Where(h => h.CinemaId == cinemaId)
                    .Join(db.Schedules, h => h.Id, s => s.HallId, (h, s) => s)
                    .Join(db.MovieSchedules, s => s.Id, ms => ms.ScheduleId, (s, ms) => ms)
                    .Join(db.Movies, ms => ms.MovieId, mv => mv.Id, (ms, mv) => mv).Distinct().ToList();
            }
            else
            {
                movieEntities = db.Movies.ToList();
            }

            List<MovieResponse> movieResponses = new List<MovieResponse>();

            foreach (MovieEntity movieEntity in movieEntities)
            {
                movieResponses.Add(Converter.MovieEntityToResponse(movieEntity));
            }

            return movieResponses;
        }

        public List<MovieResponse> GetAllMoviesInTimeRange(DateTime start, DateTime end)
        {
            var movies = db.Movies.Where(m => m.ReleaseDate >= start && m.ReleaseDate <= end).ToList();

            List<MovieResponse> movieResponses = new List<MovieResponse>();

            foreach (MovieEntity movieEntity in movies)
            {
                movieResponses.Add(Converter.MovieEntityToResponse(movieEntity));
            }

            return movieResponses;
        }

        public MovieResponse GetMovie(int id)
        {
            MovieEntity movieEntity = db.Movies.Find(id);

            if (movieEntity == null)
            {
                return null;
            }

            return Converter.MovieEntityToResponse(movieEntity);
        }

        public List<MoviePerCinemaResponse> GetDistinctMoviePerCinema()
        {
            var list = db.Cinemas.Join(db.Halls, c => c.Id, h => h.CinemaId, (c, h) => new
            {
                Id = h.Id,
                CinemaName = c.Name
            })
                    .Join(db.Schedules, h => h.Id, s => s.HallId, (h, s) => new { Id = s.Id, CinemaName = h.CinemaName })
                    .Join(db.MovieSchedules, s => s.Id, ms => ms.ScheduleId, (s, ms) => new { MovieId = ms.MovieId, CinemaName = s.CinemaName })
                    .Join(db.Movies, ms => ms.MovieId, m => m.Id, (ms, m) => new MoviePerCinemaResponse() { CinemaName = ms.CinemaName, MovieName = m.Name }).Distinct().ToList();

            return list;
        }

        public MovieResponse SaveMovie(MovieEntity movieEntity)
        {
            db.Movies.Add(movieEntity);

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                return null;
            }

            MovieResponse movieResponse = Converter.MovieEntityToResponse(movieEntity);

            return movieResponse;
        }

        public bool DeleteMovie(int id)
        {
            MovieEntity movieEntity = db.Movies.Find(id);

            if (movieEntity != null)
            {
                db.Movies.Remove(movieEntity);
                db.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
