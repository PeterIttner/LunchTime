using System.ComponentModel.DataAnnotations;

namespace LunchTime.Models.Restaurant.Entity
{
    public class RestaurantEntity
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; } = null;

        [Url]
        public string? Link { get; set; } = null;

        public string? Street { get; set; } = null;

        public string? StreetNumber { get; set; } = null;

        public string? Postcode { get; set; } = null;

        public string? City { get; set; } = null;

        public string? Phone { get; set; } = null;
    }
}
