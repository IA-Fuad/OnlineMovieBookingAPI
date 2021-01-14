using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace OnlineMovieBookingAPI.Models.EntityModels
{
    public partial class MovieEntity
    {
        public MovieEntity()
        {
            MovieSchedules = new HashSet<MovieScheduleEntity>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public decimal Rating { get; set; }

        public virtual ICollection<MovieScheduleEntity> MovieSchedules { get; set; }
    }
}
