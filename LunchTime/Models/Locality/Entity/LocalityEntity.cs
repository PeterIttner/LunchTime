using System.ComponentModel.DataAnnotations;

namespace LunchTime.Models.Locality.Entity
{
    public class LocalityEntity
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; } = null;

        [Required]
        public int? AvailableSeats { get; set; } = null;
    }
}
