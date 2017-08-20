using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdeToFoodTutorial.Models;
using OdeToFoodTutorial.Services;

namespace OdeToFoodTutorial.Controllers
{
    public class HomeController : Controller
    {
		private IRestaurantData _restaurantData;

		public HomeController(IRestaurantData data)
		{
			_restaurantData = data;
		}

		public IActionResult Index()
		{
			var model = _restaurantData.GetAllRestaurants();
			return View(model);
		}
    }
}
