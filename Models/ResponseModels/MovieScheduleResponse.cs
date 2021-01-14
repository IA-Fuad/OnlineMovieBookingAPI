using System;

#nullable disable

namespace OnlineMovieBookingAPI.Models.ResponseModels
{
    public partial class MovieScheduleResponse
    {
        public int MovieId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime Date { get; set; }
        public int TicketPrice { get; set; }
    }
}
