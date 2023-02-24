using LunchTime.Models.Appointment.Entities;
using LunchTime.Models.Locality.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LunchTime.Models.Appointment.ViewModels
{
    public class AppointmentEditor
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string? Name { get; set; } = null;

        [DataType(DataType.DateTime)]
        [Required]
        [Display(Name = "Beginn")]
        public DateTime StartTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ende")]
        public DateTime EndTime { get; set; }

        [Required]
        [Display(Name = "Titel")]
        public string? MealTitle { get; set; } = null;


        [Display(Name = "Beschreibung")]
        public string? MealDescription { get; set; } = null;


        public int? SelectedLocalityId { get; set; } = null;

        [Display(Name = "Örtlichkeit")]
        public List<SelectListItem> AvailableLocalities { get; set; } = new List<SelectListItem>();

        public AppointmentEntity ToEntity()
        {
            return new AppointmentEntity
            {
                Id = Id,
                EndTime = EndTime,
                StartTime = StartTime,
                MealDescription = MealDescription,
                MealTitle = MealTitle,
                Name = Name,
                LocalityId = SelectedLocalityId,
            };
        }

        public static AppointmentEditor Create(AppointmentEntity appointmentEntity, ICollection<LocalityViewer> localities, DateTime? initialStartTime = null)
        {
            var selectableLocalitites = localities
                .Select(l => new SelectListItem { Text = l.Name, Value = l.Id.ToString() })
                .ToList();

            return new AppointmentEditor
            {
                Id = appointmentEntity.Id,
                Name = appointmentEntity.Name,
                MealTitle = appointmentEntity.MealTitle,
                MealDescription = appointmentEntity.MealDescription,
                StartTime = initialStartTime ?? appointmentEntity.StartTime,
                EndTime = initialStartTime != null ? initialStartTime.Value.AddHours(1) : appointmentEntity.EndTime,
                AvailableLocalities = selectableLocalitites,
                SelectedLocalityId = appointmentEntity.LocalityId
            };
        }
    }
}
