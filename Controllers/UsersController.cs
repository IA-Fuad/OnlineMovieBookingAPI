using Microsoft.AspNetCore.Mvc;
using OnlineMovieBookingAPI.ControllerServices;
using OnlineMovieBookingAPI.Models.EntityModels;
using OnlineMovieBookingAPI.Models.ResponseModels;

namespace OnlineMovieBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices userServices;

        public UsersController(IUserServices services)
        {
            userServices = services;
        }

        [HttpGet("{id}")]
        public ActionResult<UserResponse> GetUser(int id)
        {
            UserResponse userResponse = userServices.GetUser(id);

            if (userResponse == null)
            {
                return NotFound();
            }

            return userResponse;
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id, UserEntity user)
        {
            if (!ModelState.IsValid || id != user.Id)
            {
                return BadRequest();
            }

            if (userServices.UpdateUser(user))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
