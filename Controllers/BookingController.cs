using Microsoft.AspNetCore.Mvc;
using OnlineMovieBookingAPI.ControllerServices;
using OnlineMovieBookingAPI.Models.EntityModels;
using OnlineMovieBookingAPI.Models.ResponseModels;

namespace OnlineMovieBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingServices bookingServices;
        public BookingController(IBookingServices services)
        {
            bookingServices = services;
        }

        [HttpGet]
        public ActionResult<BookingResponse> GetBooking(int Id)
        {
            BookingResponse bookingResponse = bookingServices.GetBooking(Id);

            if (bookingResponse == null)
            {
                return NotFound();
            }

            return bookingResponse;
        }

        [HttpPost]
        public ActionResult<BookingResponse> PostBooking(BookingEntity bookingEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            BookingResponse bookingResponse = bookingServices.BookMovie(bookingEntity);

            return CreatedAtAction("GetBooking", new { bookingEntity.Id }, bookingResponse);
        }
    }
}
