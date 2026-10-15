using RaceDay.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDay.API.Data
{
    public class Enrolment
    {
        [Key]
        public int EnrolmentId { get; set; }
        [ForeignKey("EventCategory")]
        public int CategoryId { get; set; }
        public EventCategory? EventCategory { get; set; }
        [ForeignKey("Participant")]
        public int ParticipantId { get; set; }
        public User? Participant { get; set; }
        public DateTime EnrolmentDate { get; set; } = DateTime.Now;
        public string PaymentStatus { get; set; } = "Pending";
    }
}
