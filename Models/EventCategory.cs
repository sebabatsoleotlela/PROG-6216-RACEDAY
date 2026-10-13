using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDay.API.Models
{
    public class EventCategory
    {
        [Key]
        public int CategoryId { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event? Event { get; set; }
        [Required]
        public string CategoryName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(5,2)")]
        public decimal DistanceKm { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal EntryFee { get; set; }
    }
}