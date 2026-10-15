namespace RaceDay.API.DTOs
{
    public class CreateCategoryDto
    {
        public int EventId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int MaxParticipants { get; set; }
    }
}