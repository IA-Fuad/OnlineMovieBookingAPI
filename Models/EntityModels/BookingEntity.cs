using System.ComponentModel.DataAnnotations;

#nullable disable

namespace OnlineMovieBookingAPI.Models.EntityModels
{
    public partial class BookingEntity
    {
        public int Id { get; set; }

        [Required]
        public int MovieScheduleId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int NumberOfSeat { get; set; }

        public virtual MovieScheduleEntity MovieSchedule { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
