namespace RaceDay.API.DTOs
{
    public class CreateEventDto
    {
        public string Title { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public int OrganiserId { get; set; }
    }
}
