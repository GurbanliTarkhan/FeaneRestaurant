using Microsoft.AspNetCore.Mvc;

namespace FeaneRestaurant.WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutNavbarPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
