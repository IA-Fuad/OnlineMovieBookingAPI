using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace OnlineMovieBookingAPI.Models.EntityModels
{
    public partial class CityEntity
    {
        public CityEntity()
        {
            Cinemas = new HashSet<CinemaEntity>();
            Users = new HashSet<UserEntity>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<CinemaEntity> Cinemas { get; set; }
        public virtual ICollection<UserEntity> Users { get; set; }
    }
}
