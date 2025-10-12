using Microsoft.AspNetCore.Mvc;

namespace Task.Controllers
{
    public class UsersController : Controller
    {
        public ViewResult GetAll()
        {
            List<string> users = new List<string>
            {
                "User1",
                "User2",
                "User3"
            };
            var age = 30;
            return View("Index",users);

        }
        public ViewResult Create()
        {
            return View("Create");
        }
        public ViewResult Details()
        {
            return View("Details");
        }
    }
}
