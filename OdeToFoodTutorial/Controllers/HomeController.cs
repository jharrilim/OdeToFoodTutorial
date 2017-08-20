using Microsoft.AspNetCore.Mvc;
using OdeToFoodTutorial.Entities;
using OdeToFoodTutorial.Services;
using OdeToFoodTutorial.ViewModels;

namespace OdeToFoodTutorial.Controllers
{
    public class HomeController : Controller
    {
		private IRestaurantData _restaurantData;
		private IGreeter _greeter;

		public HomeController(IRestaurantData data, IGreeter greeter)
		{
			_restaurantData = data;
			_greeter = greeter;
		}

		public IActionResult Index()
		{
			var model = new HomePageViewModel();
			model.Restaurants = _restaurantData.GetAllRestaurants();
			model.Motd = _greeter.GetGreeting();
			return View(model);
		}

		public IActionResult Details(int id)
		{
			var model = _restaurantData.Get(id);
			if (model == null)
				return RedirectToAction(nameof(Index));
			return View(model);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(RestaurantEditViewModel model)
		{
			if (ModelState.IsValid)
			{
				var restaurant = new Restaurant()
				{
					Cuisine = model.Cuisine,
					Name = model.Name
				};

				restaurant = _restaurantData.Add(restaurant);
				return RedirectToAction("Details", new { id = restaurant.Id });
			}
			return View();
		}
    }
}
