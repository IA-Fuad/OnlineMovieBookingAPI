using OnlineMovieBookingAPI.Data;
using OnlineMovieBookingAPI.Models.EntityModels;
using OnlineMovieBookingAPI.Models.ResponseModels;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace OnlineMovieBookingAPI.ControllerServices
{
    public interface IBookingServices
    {
        BookingResponse BookMovie(BookingEntity bookingReponse);
        BookingResponse GetBooking(int Id);
    }

    public class BookingServices : IBookingServices
    {
        private readonly OnlineMovieBookingContext db;

        public BookingServices(OnlineMovieBookingContext context)
        {
            db = context;
        }

        private int HallCapacity(int movieScheduleId)
        {
            int hallCapacity = db.MovieSchedules.Where(ms => ms.Id == movieScheduleId)
                .Select(ms => new { sId = ms.Id })
                .Join(db.Schedules, ms => ms.sId, s => s.Id, (ms, s) => new { hId = s.HallId })
                .Join(db.Halls, s => s.hId, h => h.Id, (s, h) => h.Capacity).FirstOrDefault();

            return hallCapacity;
        }

        private int BookedSeats(int movieScheduleId)
        {
            int bookedSeats = db.Bookings.Where(b => b.MovieScheduleId == movieScheduleId)
                .Sum(b => b.NumberOfSeat);

            return bookedSeats;
        }

        private int TotalTicketPrice(int movieScheduleId, int numberOfSeats)
        {
            int totalTicketPrice = db.MovieSchedules.FirstOrDefault(ms => ms.Id == movieScheduleId).TicketPrice * numberOfSeats;

            return totalTicketPrice;
        }

        public BookingResponse BookMovie(BookingEntity bookingEntity)
        {
            int hallCapacity = HallCapacity(bookingEntity.MovieScheduleId);

            int bookedSeats = BookedSeats(bookingEntity.MovieScheduleId);

            BookingResponse bookingReponse;

            if (bookingEntity.NumberOfSeat + bookedSeats > hallCapacity)
            {
                bookingReponse = Converter.BookingEntityToResponse(false, 0, 0);
            }
            else
            {
                int totalTicketPrice = TotalTicketPrice(bookingEntity.MovieScheduleId, bookingEntity.NumberOfSeat);

                bookingReponse = Converter.BookingEntityToResponse(true, bookingEntity.NumberOfSeat, totalTicketPrice);

                db.Bookings.Add(bookingEntity);

                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException)
                {
                    return null;
                }
            }

            return bookingReponse;
        }

        public BookingResponse GetBooking(int Id)
        {
            BookingEntity bookingEntity = db.Bookings.Find(Id);

            if (bookingEntity == null)
            {
                return null;
            }

            int numberOfSeats = bookingEntity.NumberOfSeat;
            int totalTicketPrice = TotalTicketPrice(bookingEntity.MovieScheduleId, numberOfSeats);

            return Converter.BookingEntityToResponse(true, numberOfSeats, totalTicketPrice);
        }
    }
}
