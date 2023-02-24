using LunchTime.Models.Appointment.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LunchTime.Models.Appointment.ViewModels
{
    public class AppointmentViewer
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string? Name { get; set; } = null;

        [Display(Name = "Titel")]
        public string? MealTitle { get; set; } = null;

        [Display(Name = "Beschreibung")]
        public string? MealDescription { get; set; } = null;

        [DataType(DataType.DateTime)]
        [Display(Name = "Beginn")]
        public DateTime StartTime { get; set; }

        public static AppointmentViewer Create(AppointmentEntity entity)
        {
            return new AppointmentViewer
            {
                Id = entity.Id,
                Name = entity.Name,
                MealDescription = entity.MealDescription,
                MealTitle = entity.MealTitle,
                StartTime = entity.StartTime,
            };
        }
    }
}
