using System;

#nullable disable

namespace OnlineMovieBookingAPI.Models.ResponseModels
{
    public partial class ScheduleResponse
    {
        public int HallId { get; set; }
        public int Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
