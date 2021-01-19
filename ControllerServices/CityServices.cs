using OnlineMovieBookingAPI.Data;
using OnlineMovieBookingAPI.Models.EntityModels;
using OnlineMovieBookingAPI.Models.ResponseModels;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace OnlineMovieBookingAPI.ControllerServices
{
    public interface ICityServices
    {
        List<CityResponse> GetAllCity();
        CityResponse GetCity(int id);
        CityResponse SaveCity(CityEntity cityResponse);
    }

    public class CityServices : ICityServices
    {
        private readonly OnlineMovieBookingContext db;

        public CityServices(OnlineMovieBookingContext context)
        {
            db = context;
        }

        public List<CityResponse> GetAllCity()
        {
            List<CityEntity> cityEntities = db.Cities.ToList();

            List<CityResponse> cityResponses = new List<CityResponse>();

            foreach (CityEntity cityEntity in cityEntities)
            {
                cityResponses.Add(Converter.CityEntityToResponse(cityEntity));
            }

            return cityResponses;
        }

        public CityResponse GetCity(int id)
        {
            CityEntity cityEntity = db.Cities.Find(id);

            if (cityEntity == null)
            {
                return null;
            }

            return Converter.CityEntityToResponse(cityEntity);
        }

        public CityResponse SaveCity(CityEntity cityEntity)
        {
            db.Cities.Add(cityEntity);

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                return null;
            }

            CityResponse cityResponse = Converter.CityEntityToResponse(cityEntity);

            return cityResponse;
        }
    }
}
