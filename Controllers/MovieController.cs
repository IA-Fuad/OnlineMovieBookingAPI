using Microsoft.AspNetCore.Mvc;
using OnlineMovieBookingAPI.ControllerServices;
using OnlineMovieBookingAPI.Models.EntityModels;
using OnlineMovieBookingAPI.Models.ResponseModels;
using System;
using System.Collections.Generic;

namespace OnlineMovieBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieServices movieServices;
        public MovieController(IMovieServices services)
        {
            movieServices = services;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieResponse>> GetAllMovies(int? cinemaId)
        {
            List<MovieResponse> movieResponses = movieServices.GetAllMovies(cinemaId);

            if (movieResponses == null)
            {
                return NotFound();
            }

            return movieResponses;
        }

        [HttpGet]
        [Route("Distinct")]
        public ActionResult<IEnumerable<MoviePerCinemaResponse>> GetDisctinctMoviePerCinema()
        {
            return movieServices.GetDistinctMoviePerCinema();
        }

        [HttpGet("{id}")]
        public ActionResult<MovieResponse> GetMovie(int id)
        {
            MovieResponse movieResponse = movieServices.GetMovie(id);

            if (movieResponse == null)
            {
                return NotFound();
            }

            return movieResponse;
        }

        [HttpGet("TimeRange")]
        public ActionResult<IEnumerable<MovieResponse>> GetMoviesInTimeRange(DateTime start, DateTime end)
        {
            var movieResponses = movieServices.GetAllMoviesInTimeRange(start, end);

            if (movieResponses == null)
            {
                return NotFound();
            }

            return movieResponses;
        }

        [HttpPost]
        public ActionResult<MovieResponse> PostMovie(MovieEntity movieEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            MovieResponse movieResponse = movieServices.SaveMovie(movieEntity);

            return CreatedAtAction("GetMovie", new { id = movieEntity.Id }, movieResponse);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            if (movieServices.DeleteMovie(id))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
