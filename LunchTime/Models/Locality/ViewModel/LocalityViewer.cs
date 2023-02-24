using LunchTime.Models.Locality.Entity;
using System.ComponentModel.DataAnnotations;

namespace LunchTime.Models.Locality.ViewModel
{
    public class LocalityViewer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Örtlichkeit")]
        public string? Name { get; set; } = null;

        [Required]
        [Range(1, 200)]
        [Display(Name = "Anzahl Sitzplätze")]
        public int? AvailableSeats { get; set; } = null;

        public static LocalityViewer Create(LocalityEntity entity)
        {
            return new LocalityViewer
            {
                Id = entity.Id,
                Name = entity.Name,
                AvailableSeats = entity.AvailableSeats
            };
        }
    }
}
