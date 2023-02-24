using LunchTime.Models.Restaurant.Entity;
using System.ComponentModel.DataAnnotations;

namespace LunchTime.Models.Restaurant.ViewModel
{
    public class RestaurantEditor
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

        public static RestaurantEditor Create(RestaurantEntity entity)
        {
            return new RestaurantEditor
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

        public RestaurantEntity ToEntity()
        {
            return new RestaurantEntity
            {
                Id = Id,
                Name = Name,
                City = City,
                Link = Link,
                Phone = Phone,
                Postcode = Postcode,
                Street = Street,
                StreetNumber = StreetNumber,
            };
        }
    }
}
