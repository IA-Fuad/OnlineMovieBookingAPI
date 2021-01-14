using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace OnlineMovieBookingAPI.Models.EntityModels
{
    public partial class CinemaEntity
    {
        public CinemaEntity()
        {
            Halls = new HashSet<HallEntity>();
        }

        public int Id { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual CityEntity City { get; set; }
        public virtual ICollection<HallEntity> Halls { get; set; }
    }
}
