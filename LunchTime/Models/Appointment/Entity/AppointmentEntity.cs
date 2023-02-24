using LunchTime.Models.Locality.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LunchTime.Models.Appointment.Entities
{
    [Table("Appointment")]
    public class AppointmentEntity
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; } = null;

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime StartTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        [Required]
        public string? MealTitle { get; set; } = null;

        public string? MealDescription { get; set; } = null;

        public LocalityEntity? Locality { get; set; } = null;
        public int? LocalityId { get; set; }
    }
}
