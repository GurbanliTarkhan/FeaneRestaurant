using Microsoft.AspNetCore.Mvc;

namespace FeaneRestaurant.WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutSidebarPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
