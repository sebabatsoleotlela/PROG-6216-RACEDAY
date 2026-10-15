namespace RaceDay.API.DTOs
{
    public class CreateEventCategoryDto
    {
        public int EventId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public decimal DistanceKm { get; set; }
        public decimal EntryFee { get; set; }
    }
}