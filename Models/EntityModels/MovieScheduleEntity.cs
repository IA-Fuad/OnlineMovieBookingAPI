using System;
using System.Collections.Generic;


#nullable disable

namespace OnlineMovieBookingAPI.Models.EntityModels
{
    public partial class MovieScheduleEntity
    {
        public MovieScheduleEntity()
        {
            Bookings = new HashSet<BookingEntity>();
        }

        public int Id { get; set; }
        public int MovieId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime Date { get; set; }
        public int TicketPrice { get; set; }

        public virtual MovieEntity Movie { get; set; }
        public virtual ScheduleEntity Schedule { get; set; }
        public virtual ICollection<BookingEntity> Bookings { get; set; }
    }
}
