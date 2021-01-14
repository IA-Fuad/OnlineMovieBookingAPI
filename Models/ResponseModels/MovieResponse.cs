using System;

#nullable disable

namespace OnlineMovieBookingAPI.Models.ResponseModels
{
    public partial class MovieResponse
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Rating { get; set; }
    }
}
