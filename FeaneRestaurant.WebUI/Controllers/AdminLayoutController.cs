using Microsoft.AspNetCore.Mvc;

namespace FeaneRestaurant.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
