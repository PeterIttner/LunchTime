using AspnetCore.Unpoly;
using LunchTime.Database;
using LunchTime.Models.Appointment.Entities;
using LunchTime.Models.Appointment.ViewModels;
using LunchTime.Models.Locality.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LunchTime.Controllers
{
    public class AppointmentController : UpController
    {
        private readonly DatabaseContext _db;

        public AppointmentController(DatabaseContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db
                .Appointment
                .OrderBy(entity => entity.StartTime)
                .Select(entity => AppointmentViewer.Create(entity))
                .ToList());
        }

        public ActionResult Filter([FromQuery(Name = "query")] string query)
        {
            if (query == null)
            {
                query = string.Empty;
            }

            var filterLowerCase = query.ToLowerInvariant();
            ViewBag.Query = query;

            var queryParts = filterLowerCase.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            var appointments = _db
                .Appointment
                .Where(appointment => appointment.Name != null);

            foreach (var queryPart in queryParts)
            {
                appointments = appointments.Where(appointment => appointment.Name.ToLower().Contains(queryPart));
            }

            var result = appointments
            .OrderBy(entity => entity.StartTime)
                .Select(entity => AppointmentViewer.Create(entity))
                .ToList();

            return UpView("Index", result, ".appointments"); ;
        }

        public ActionResult Upcoming()
        {
            var now = DateTime.Now;

            return PartialView(_db
                .Appointment
                .OrderBy(entity => entity.StartTime)
                .Where(entity => entity.StartTime > now && entity.StartTime < now.AddHours(6))
                .Take(5)
                .Select(entity => AppointmentViewer.Create(entity))
                .ToList());
        }

        public ActionResult Create()
        {
            return View(AppointmentEditor.Create(
                new AppointmentEntity(),
                _db.Localities.Select(entity => LocalityViewer.Create(entity)).ToList(),
                DateTime.Now.AddHours(2)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AppointmentEditor editor)
        {
            if (!ModelState.IsValid)
            {
                return UpBadRequest(editor);
            }

            var appointment = editor.ToEntity();

            _db.Appointment.Add(appointment);
            await _db.SaveChangesAsync();
            return UpAccept();
        }


        public async Task<ActionResult> Edit(int id)
        {
            var appointment = await _db.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return RedirectToAction("Index");
            }

            return View(AppointmentEditor.Create(
                appointment,
                _db.Localities.Select(entity => LocalityViewer.Create(entity)).ToList()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AppointmentEditor editor)
        {
            if (!ModelState.IsValid)
            {
                return UpBadRequest(editor);
            }
            _db.Update(editor.ToEntity());
            await _db.SaveChangesAsync();
            return UpAccept();
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _db.Appointment.FindAsync(id);
            return View(AppointmentViewer.Create(entity));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var entity = await _db.Appointment.FindAsync(id);

            if (entity == null)
            {
                ModelState.AddModelError("", "Verabredung existiert nicht mehr");
            }

            if (!ModelState.IsValid || entity == null)
            {
                return UpBadRequest(AppointmentViewer.Create(entity), "Delete");
            }

            _db.Appointment.Remove(entity);
            await _db.SaveChangesAsync();
            return UpAccept();
        }
    }
}
