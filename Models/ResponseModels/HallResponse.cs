#nullable disable

namespace OnlineMovieBookingAPI.Models.ResponseModels
{
    public partial class HallResponse
    {
        public int CinemaId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
