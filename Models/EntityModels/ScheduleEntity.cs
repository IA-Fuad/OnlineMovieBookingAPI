using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace OnlineMovieBookingAPI.Models.EntityModels
{
    public partial class ScheduleEntity
    {
        public ScheduleEntity()
        {
            MovieSchedules = new HashSet<MovieScheduleEntity>();
        }

        public int Id { get; set; }

        [Required]
        public int HallId { get; set; }

        [Required]
        public int Day { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        public virtual HallEntity Hall { get; set; }
        public virtual ICollection<MovieScheduleEntity> MovieSchedules { get; set; }
    }
}
