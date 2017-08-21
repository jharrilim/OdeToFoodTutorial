using Microsoft.AspNetCore.Mvc;

namespace OdeToFoodTutorial.ViewComponents
{
    public class LoginLogoutViewComponent : ViewComponent
    {
		public IViewComponentResult Invoke()
		{
			return View();
		}
    }
}
