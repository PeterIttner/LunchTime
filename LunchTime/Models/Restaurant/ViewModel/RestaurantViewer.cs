using LunchTime.Models.Restaurant.Entity;
using System.ComponentModel.DataAnnotations;

namespace LunchTime.Models.Restaurant.ViewModel
{
    public class RestaurantViewer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Restaurant Name")]
        public string? Name { get; set; } = null;

        [Url]
        [Display(Name = "Webseite")]
        public string? Link { get; set; } = null;

        [Display(Name = "Straße")]
        public string? Street { get; set; } = null;

        [Display(Name = "Hausnummer")]
        public string? StreetNumber { get; set; } = null;

        [Display(Name = "Postleitzahl")]
        public string? Postcode { get; set; } = null;

        [Display(Name = "Ort")]
        public string? City { get; set; } = null;

        [Display(Name = "Telefon")]
        public string? Phone { get; set; } = null;

        public static RestaurantViewer Create(RestaurantEntity entity)
        {
            return new RestaurantViewer
            {
                Id = entity.Id,
                Name = entity.Name,
                City = entity.City,
                Link = entity.Link,
                Phone = entity.Phone,
                Postcode = entity.Postcode,
                Street = entity.Street,
                StreetNumber = entity.StreetNumber,
            };
        }        
    }
}
