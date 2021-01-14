using Microsoft.AspNetCore.Mvc;
using OnlineMovieBookingAPI.ControllerServices;
using OnlineMovieBookingAPI.Models.EntityModels;
using OnlineMovieBookingAPI.Models.ResponseModels;
using System.Collections.Generic;

namespace OnlineMovieBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityServices cityServices;
        public CityController(ICityServices services)
        {
            cityServices = services;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CityResponse>> GetAllCity()
        {
            return cityServices.GetAllCity();
        }

        [HttpGet("{id}")]
        public ActionResult<CityResponse> GetCity(int id)
        {
            CityResponse cityResponse = cityServices.GetCity(id);

            if (cityResponse == null)
            {
                return NotFound();
            }

            return cityResponse;
        }

        [HttpPost]
        public ActionResult<CityResponse> PostCity(CityEntity cityEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            CityResponse cityResponse = cityServices.SaveCity(cityEntity);

            return CreatedAtAction("GetCity", new { id = cityEntity.Id }, cityResponse);
        }
    }
}
