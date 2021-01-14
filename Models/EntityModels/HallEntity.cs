using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace OnlineMovieBookingAPI.Models.EntityModels
{
    public partial class HallEntity
    {
        public HallEntity()
        {
            Schedules = new HashSet<ScheduleEntity>();
        }

        public int Id { get; set; }

        [Required]
        public int CinemaId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }

        public virtual CinemaEntity Cinema { get; set; }
        public virtual ICollection<ScheduleEntity> Schedules { get; set; }
    }
}
