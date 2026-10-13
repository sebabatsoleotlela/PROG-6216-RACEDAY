using RaceDay.API.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDay.API.Models
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }
        [ForeignKey("Enrolment")]
        public int EnrolmentId { get; set; }
        public Enrolment? Enrolment { get; set; }
        public TimeSpan? FinishTime { get; set; }
        public int? OverallPosition { get; set; }
        public int? CategoryPosition { get; set; }
        public DateTime RecordedAt { get; set; } = DateTime.Now;
    }
}