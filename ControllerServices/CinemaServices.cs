using OnlineMovieBookingAPI.Data;
using OnlineMovieBookingAPI.Models.EntityModels;
using OnlineMovieBookingAPI.Models.ResponseModels;
using System.Collections.Generic;
using System.Linq;

namespace OnlineMovieBookingAPI.ControllerServices
{
    public interface ICinemaServices
    {
        List<CinemaResponse> GetAllCinema(int CityId);
        CinemaResponse GetCinema(int id);
        CinemaResponse SaveCinema(CinemaEntity cinemaEntity);
    }

    public class CinemaServices : ICinemaServices
    {
        private readonly OnlineMovieBookingContext db;

        public CinemaServices(OnlineMovieBookingContext context)
        {
            db = context;
        }

        public List<CinemaResponse> GetAllCinema(int CityId)
        {
            List<CinemaEntity> cinemaEntities;

            if (CityId != 0)
            {
                if (db.Cinemas.FirstOrDefault(c => c.CityId == CityId) == null)
                {
                    return null;
                }

                cinemaEntities = db.Cinemas.Where(cn => cn.CityId == CityId).ToList();
            }
            else
            {
                cinemaEntities = db.Cinemas.ToList();
            }

            List<CinemaResponse> cinemaResponses = new List<CinemaResponse>();

            foreach (CinemaEntity cinemaEntity in cinemaEntities)
            {
                cinemaResponses.Add(Converter.CinemaEntityToResponse(cinemaEntity));
            }

            return cinemaResponses;
        }

        public CinemaResponse GetCinema(int id)
        {
            CinemaEntity cinemaEntity = db.Cinemas.Find(id);

            if (cinemaEntity == null)
            {
                return null;
            }

            return Converter.CinemaEntityToResponse(cinemaEntity);
        }

        public CinemaResponse SaveCinema(CinemaEntity cinemaEntity)
        {
            db.Cinemas.Add(cinemaEntity);
            db.SaveChanges();

            CinemaResponse cinemaResponse = Converter.CinemaEntityToResponse(cinemaEntity);

            return cinemaResponse;
        }
    }
}
