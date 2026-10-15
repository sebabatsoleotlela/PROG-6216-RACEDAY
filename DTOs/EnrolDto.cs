namespace RaceDay.API.DTOs
{
    public class EnrolDto
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int CategoryId { get; set; } // The chosen race category (e.g., 5km, 10km)
    }
}