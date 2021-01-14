namespace OnlineMovieBookingAPI.Models.ResponseModels
{
    public partial class BookingResponse
    {
        public bool Booked { get; set; }
        public int NumberOfSeats { get; set; }
        public int TotalPrice { get; set; }
    }
}
