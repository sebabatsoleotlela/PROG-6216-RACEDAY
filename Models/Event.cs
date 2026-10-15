using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDay.API.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [ForeignKey("Organiser")]
        public int OrganiserId { get; set; }
        public User? Organiser { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public double Distance { get; set; } // Required by rubric

        [Required]
        public string EventType { get; set; } = "Run"; // Run, Walk, or Cycle

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}