using OnlineMovieBookingAPI.Models.EntityModels;
using OnlineMovieBookingAPI.Models.ResponseModels;

namespace OnlineMovieBookingAPI.ControllerServices
{
    public class Converter
    {
        public static MovieEntity MovieResponseToEntity(MovieResponse movieResponse)
        {
            MovieEntity movieEntity = new MovieEntity()
            {
                Name = movieResponse.Name,
                Rating = movieResponse.Rating,
                ReleaseDate = movieResponse.ReleaseDate
            };

            return movieEntity;
        }

        public static MovieResponse MovieEntityToResponse(MovieEntity movieEntity)
        {
            MovieResponse movieResponse = new MovieResponse()
            {
                Name = movieEntity.Name,
                Rating = movieEntity.Rating,
                ReleaseDate = movieEntity.ReleaseDate
            };

            return movieResponse;
        }

        public static CinemaEntity CinemaResponseToEntity(CinemaResponse cinemaResponse)
        {
            CinemaEntity cinemaEntity = new CinemaEntity()
            {
                Name = cinemaResponse.Name,
                CityId = cinemaResponse.CityId
            };

            return cinemaEntity;
        }

        public static CinemaResponse CinemaEntityToResponse(CinemaEntity cinemaEntity)
        {
            CinemaResponse cinemaResponse = new CinemaResponse()
            {
                Name = cinemaEntity.Name,
                CityId = cinemaEntity.CityId
            };

            return cinemaResponse;
        }

        public static CityEntity CityResponseToEntity(CityResponse cityResponse)
        {
            CityEntity cityEntity = new CityEntity()
            {
                Name = cityResponse.Name
            };

            return cityEntity;
        }

        public static CityResponse CityEntityToResponse(CityEntity cityEntity)
        {
            CityResponse cityResponse = new CityResponse()
            {
                Name = cityEntity.Name
            };

            return cityResponse;
        }

        public static HallEntity HallResponseToEntity(HallResponse hallResponse)
        {
            HallEntity hallEntity = new HallEntity()
            {
                Name = hallResponse.Name,
                Capacity = hallResponse.Capacity,
                CinemaId = hallResponse.CinemaId
            };

            return hallEntity;
        }

        public static HallResponse HallEntityToResponse(HallEntity hallEntity)
        {
            HallResponse hallResponse = new HallResponse()
            {
                Name = hallEntity.Name,
                Capacity = hallEntity.Capacity,
                CinemaId = hallEntity.CinemaId
            };

            return hallResponse;
        }

        public static ScheduleEntity ScheduleResponseToEntity(ScheduleResponse scheduleResponse)
        {
            ScheduleEntity scheduleEntity = new ScheduleEntity()
            {
                HallId = scheduleResponse.HallId,
                Day = scheduleResponse.Day,
                StartTime = scheduleResponse.StartTime,
                EndTime = scheduleResponse.EndTime
            };

            return scheduleEntity;
        }

        public static ScheduleResponse ScheduleEntityToResponse(ScheduleEntity scheduleEntity)
        {
            ScheduleResponse scheduleResponse = new ScheduleResponse()
            {
                HallId = scheduleEntity.HallId,
                Day = scheduleEntity.Day,
                StartTime = scheduleEntity.StartTime,
                EndTime = scheduleEntity.EndTime
            };

            return scheduleResponse;
        }

        public static BookingResponse BookingEntityToResponse(bool booked, int numberOfSeats, int totalTicketPrice)
        {

            BookingResponse bookingResponse = new BookingResponse()
            {
                Booked = booked,
                NumberOfSeats = numberOfSeats,
                TotalPrice = totalTicketPrice
            };

            return bookingResponse;
        }

        public static UserResponse UserEntityToResponse(UserEntity userEntity)
        {
            UserResponse userResponse = new UserResponse()
            {
                Firstname = userEntity.Firstname,
                Lastname = userEntity.Lastname,
                Gender = userEntity.Gender,
                CityId = userEntity.CityId,
                Dateofbirth = userEntity.Dateofbirth
            };

            return userResponse;
        }
    }
}
