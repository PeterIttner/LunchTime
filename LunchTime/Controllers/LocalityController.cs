using AspnetCore.Unpoly;
using LunchTime.Database;
using LunchTime.Models.Locality.Entity;
using LunchTime.Models.Locality.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LunchTime.Controllers
{
    public class LocalityController : UpController
    {
        private readonly DatabaseContext _db;

        public LocalityController(DatabaseContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db
                .Localities
                .OrderBy(r => r.Name)
                .Select(l => LocalityViewer.Create(l))
                .ToList());
        }

        public ActionResult Create()
        {
            return View(LocalityEditor.Create(new LocalityEntity()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LocalityEditor viewModel)
        {
            if (!ModelState.IsValid)
            {
                return UpBadRequest(viewModel);
            }

            _db.Localities.Add(viewModel.ToEntity());
            await _db.SaveChangesAsync();
            return UpAccept();
        }


        public async Task<ActionResult> Edit(int id)
        {
            var entity = await _db.Localities.FindAsync(id);
            return View(LocalityEditor.Create(entity));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LocalityEditor viewModel)
        {
            if (!ModelState.IsValid)
            {
                return UpBadRequest(viewModel);
            }
            
            _db.Update(viewModel.ToEntity());
            await _db.SaveChangesAsync();
            return UpAccept();
        }

        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _db.Localities.FindAsync(id);
            return View(LocalityViewer.Create(entity));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var entity = await _db.Localities.FindAsync(id);

            if (entity == null)
            {
                ModelState.AddModelError("", "Örtlichkeit existiert nicht mehr");
            }

            if (!ModelState.IsValid || entity == null)
            {
                return UpBadRequest(LocalityViewer.Create(entity), "Delete");
            }

            _db.Localities.Remove(entity);

            try
            {
                await _db.SaveChangesAsync();
                return UpAccept();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Örtlichkeit konnte nicht gelöscht werden");
                return UpBadRequest(LocalityViewer.Create(entity), "Delete");
            }
        }
    }
}
