using AspnetCore.Unpoly;
using LunchTime.Database;
using LunchTime.Models.Restaurant.Entity;
using LunchTime.Models.Restaurant.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LunchTime.Controllers
{
    public class RestaurantController : UpController
    {
        private readonly DatabaseContext _db;

        public RestaurantController(DatabaseContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db
                .Restaurants
                .OrderBy(r => r.Id)
                .Select(r => RestaurantViewer.Create(r))
                .Reverse()
                .ToList());
        }

        public async Task<ActionResult> Details(int id)
        {
            var entity = await _db.Restaurants.FindAsync(id);
            return View(RestaurantViewer.Create(entity));
        }

        public ActionResult Create()
        {
            return View(RestaurantEditor.Create(new RestaurantEntity()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RestaurantEditor viewModel)
        {
            if (!ModelState.IsValid)
            {
                return UpBadRequest(viewModel);
            }

            _db.Restaurants.Add(viewModel.ToEntity());
            await _db.SaveChangesAsync();
            return UpAccept();
        }


        public async Task<ActionResult> Edit(int id)
        {
            var entity = await _db.Restaurants.FindAsync(id);
            return View(RestaurantEditor.Create(entity));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RestaurantEditor viewModel)
        {
            if (!ModelState.IsValid)
            {
                return UpBadRequest(viewModel);
            }

            _db.Update(viewModel.ToEntity());
            return UpAccept();
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _db.Restaurants.FindAsync(id);
            return View(RestaurantViewer.Create(entity));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var entity = await _db.Restaurants.FindAsync(id);

            if (entity == null)
            {
                ModelState.AddModelError("", "Restaurant existiert nicht mehr");
            }

            if (!ModelState.IsValid || entity == null)
            {
                return UpBadRequest(RestaurantViewer.Create(entity), "Delete");
            }

            _db.Restaurants.Remove(entity);
            await _db.SaveChangesAsync();
            return UpAccept();
        }
    }
}
