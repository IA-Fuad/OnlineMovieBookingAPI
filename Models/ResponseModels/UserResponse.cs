using System;

#nullable disable

namespace OnlineMovieBookingAPI.Models.ResponseModels
{
    public partial class UserResponse
    {
        public int CityId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public DateTime? Dateofbirth { get; set; }
    }
}
