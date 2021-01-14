using OnlineMovieBookingAPI.Data;
using OnlineMovieBookingAPI.Models.EntityModels;
using OnlineMovieBookingAPI.Models.ResponseModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace OnlineMovieBookingAPI.ControllerServices
{
    public interface IHallServices
    {
        HallResponse GetHall(int id);
        HallResponse SaveHall(HallEntity hallResponse);
        void DeleteHallWithoutSchedule();
    }

    public class HallServices : IHallServices
    {
        private readonly OnlineMovieBookingContext db;

        public HallServices(OnlineMovieBookingContext context)
        {
            db = context;
        }

        public HallResponse GetHall(int id)
        {
            HallEntity hallEntity = db.Halls.Find(id);

            if (hallEntity == null)
            {
                return null;
            }

            return Converter.HallEntityToResponse(hallEntity);
        }

        public HallResponse SaveHall(HallEntity hallEntity)
        {
            db.Halls.Add(hallEntity);
            db.SaveChanges();

            HallResponse hallResponse = Converter.HallEntityToResponse(hallEntity);

            return hallResponse;
        }

        public void DeleteHallWithoutSchedule()
        {
            var halls = db.Halls
                ?.Join(db.Schedules, h => h.Id, s => s.HallId, (h, s) => new { hall = h, schedule = s })
                ?.GroupJoin(db.MovieSchedules, hs => hs.schedule.Id, ms => ms.ScheduleId, (hs, ms) =>
                new { hall = hs.hall, movieSchedule = ms })
                ?.SelectMany(ms => ms.movieSchedule.DefaultIfEmpty(), (h, s) => new { hall = h.hall, schedule = s })
                ?.Where(hms => hms.schedule == null)
                ?.Select(hms => hms.hall).ToList();

            foreach (var hallEntity in halls)
            {
                Debug.WriteLine(hallEntity.Name);
                db.Halls.Remove(hallEntity);
                db.SaveChanges();
                return;
            }
        }
    }
}
