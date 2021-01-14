using Microsoft.AspNetCore.Mvc;
using OnlineMovieBookingAPI.ControllerServices;
using OnlineMovieBookingAPI.Models.ResponseModels;
using OnlineMovieBookingAPI.Models.EntityModels;

namespace OnlineMovieBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleServices scheduleService;
        private readonly IHallServices hallServices;
        public ScheduleController(IScheduleServices sServices, IHallServices hServices)
        {
            scheduleService = sServices;
            hallServices = hServices;
        }

        [HttpGet]
        public ActionResult<ScheduleResponse> GetSchedule(int id)
        {
            return scheduleService.GetSchedule(id);
        }

        [HttpPost]
        public ActionResult<ScheduleResponse> PostSchedule(ScheduleEntity scheduleEntity, int hallId)
        {
            if (!ModelState.IsValid || hallServices.GetHall(hallId) == null)
            {
                return BadRequest();
            }

            scheduleEntity.HallId = hallId;

            ScheduleResponse scheduleResponse = scheduleService.SaveSchedule(scheduleEntity);

            return CreatedAtAction("GetSchedule", new { id = scheduleEntity.Id }, scheduleResponse);
        }

        [HttpPut("{id}")]
        public IActionResult PutSchedule(ScheduleEntity scheduleEntity, int id, int hallId)
        {
            if (!ModelState.IsValid || scheduleEntity.Id != id || scheduleEntity.HallId != hallId)
            {
                return BadRequest();
            }

            if (!scheduleService.UpdateSchedule(scheduleEntity, id, hallId))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
