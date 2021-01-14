using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace OnlineMovieBookingAPI.Models.EntityModels
{
    public partial class UserEntity
    {
        public UserEntity()
        {
            Bookings = new HashSet<BookingEntity>();
        }

        public int Id { get; set; }
        
        [Required]
        public int CityId { get; set; }

        [Required]
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime? Dateofbirth { get; set; }

        public virtual CityEntity City { get; set; }
        public virtual ICollection<BookingEntity> Bookings { get; set; }
    }
}
