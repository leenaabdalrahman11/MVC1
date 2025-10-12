using Microsoft.AspNetCore.Mvc;
using Task.Data;

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
    }
}
