using Microsoft.AspNetCore.Mvc;

namespace FeaneRestaurant.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
