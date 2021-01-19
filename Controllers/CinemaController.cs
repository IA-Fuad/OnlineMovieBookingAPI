using Microsoft.AspNetCore.Mvc;
using OnlineMovieBookingAPI.ControllerServices;
using OnlineMovieBookingAPI.Models.EntityModels;
using OnlineMovieBookingAPI.Models.ResponseModels;
using System.Collections.Generic;

namespace OnlineMovieBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaServices cinemaServices;
        public CinemaController(ICinemaServices services)
        {
            cinemaServices = services;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CinemaResponse>> GetAllCinema(int CityId = 0)
        {
            List<CinemaResponse> cinemaResponses = cinemaServices.GetAllCinema(CityId);

            if (cinemaResponses == null)
            {
                return NotFound();
            }

            return cinemaResponses;
        }

        [HttpGet("{id}")]
        public ActionResult<CinemaResponse> GetCinema(int id)
        {
            CinemaResponse cinemaResponse = cinemaServices.GetCinema(id);

            if (cinemaResponse == null)
            {
                return NotFound();
            }

            return cinemaResponse;
        }

        [HttpPost]
        public ActionResult<CinemaResponse> PostCinema(CinemaEntity cinemaEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            CinemaResponse cinemaResponse = cinemaServices.SaveCinema(cinemaEntity);

            if (cinemaResponse == null)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetCinema", new { id = cinemaEntity.Id }, cinemaResponse);
        }
    }
}
