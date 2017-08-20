using OdeToFoodTutorial.Entities;
using System.Collections.Generic;

namespace OdeToFoodTutorial.ViewModels
{
    public class HomePageViewModel
    {
		public string Motd { get; set; }
		public IEnumerable<Restaurant> Restaurants { get; set; }

	}
}
