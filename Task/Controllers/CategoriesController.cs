using Microsoft.AspNetCore.Mvc;
using Task.Data;
using Task.Models;

namespace Task.Controllers
{
    public class CategoriesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ViewResult Index()
        {
            var categories = db.Categories.ToList();
            return View("Index",categories);
        }
        public ViewResult Details(int id) { 
            var category = db.Categories.Find(id);
            return View("Details",category);
        }
        public ViewResult Create() { 
            return View("Create",new Category());
        }
        public IActionResult Store(Category request) { 
            if (!ModelState.IsValid) {
                return View("Create",request);
            }
            db.Categories.Add(request);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var category = db.Categories.Find(id);
            if (category == null)
                return NotFound($"No category found with ID mm= {id}");
            return View("Update", category);
        }
        [HttpPost]
        public IActionResult Edit(Category request)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", request);
            }

            var category = db.Categories.Find(request.Id);
            if (category == null)
            {
                return NotFound($"No category found with ID = {request.Id}");
            }
            category.Name = request.Name;
            category.Description = request.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
