using Microsoft.AspNetCore.Mvc;
using OnlineMovieBookingAPI.ControllerServices;
using OnlineMovieBookingAPI.Models.EntityModels;
using OnlineMovieBookingAPI.Models.ResponseModels;

namespace OnlineMovieBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly IHallServices hallServices;
        private readonly ICinemaServices cinemaServices;
        public HallController(IHallServices hServices, ICinemaServices cServices)
        {
            hallServices = hServices;
            cinemaServices = cServices;
        }

        [HttpGet("{id}")]
        public ActionResult<HallResponse> GetHall(int id)
        {
            return hallServices.GetHall(id);
        }

        [HttpPost]
        public ActionResult<HallResponse> PostHall(HallEntity hallEntity, int cinemaId)
        {
            if (!ModelState.IsValid || cinemaServices.GetCinema(cinemaId) == null)
            {
                return BadRequest();
            }

            hallEntity.CinemaId = cinemaId;

            HallResponse hallResponse = hallServices.SaveHall(hallEntity);

            if (hallResponse == null)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetHall", new { id = hallEntity.Id }, hallResponse);
        }

        [HttpDelete]
        public IActionResult DeleteHallWithoutSchedule()
        {
            hallServices.DeleteHallWithoutSchedule();

            return NoContent();
        }
    }
}
