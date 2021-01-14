using Microsoft.EntityFrameworkCore;
using OnlineMovieBookingAPI.Data;
using OnlineMovieBookingAPI.Models.EntityModels;
using OnlineMovieBookingAPI.Models.ResponseModels;
using System.Linq;

namespace OnlineMovieBookingAPI.ControllerServices
{
    public interface IScheduleServices
    {
        ScheduleResponse GetSchedule(int id);
        ScheduleResponse SaveSchedule(ScheduleEntity scheduleResponse);
        bool UpdateSchedule(ScheduleEntity scheduleEntity, int id, int hallId);
    }


    public class ScheduleServices : IScheduleServices
    {
        private readonly OnlineMovieBookingContext db;

        public ScheduleServices(OnlineMovieBookingContext context)
        {
            db = context;
        }

        public ScheduleResponse GetSchedule(int id)
        {
            ScheduleEntity scheduleEntity = db.Schedules.Find(id);

            if (scheduleEntity == null)
            {
                return null;
            }

            return Converter.ScheduleEntityToResponse(scheduleEntity);
        }

        public ScheduleResponse SaveSchedule(ScheduleEntity scheduleEntity)
        {
            db.Schedules.Add(scheduleEntity);
            db.SaveChanges();

            ScheduleResponse scheduleResponse = Converter.ScheduleEntityToResponse(scheduleEntity);

            return scheduleResponse;
        }

        public bool UpdateSchedule(ScheduleEntity scheduleEntity, int id, int hallId)
        {
            if (!db.Schedules.Any(s => s.Id == id) || !db.Halls.Any(h => h.Id == hallId))
            {
                return false;
            }

            db.Entry(scheduleEntity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return true;
        }
    }
}
