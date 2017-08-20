using OdeToFoodTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFoodTutorial.Services
{

	public interface IRestaurantData
	{
		IEnumerable<Restaurant> GetAllRestaurants();
	}

	public class InMemoryRestaurantData : IRestaurantData
	{
		private List<Restaurant> _restaurants;

		public InMemoryRestaurantData()
		{
			_restaurants = new List<Restaurant>
			{
				new Restaurant { Id = 0, Name = "McDonalds"},
				new Restaurant { Id = 1, Name = "Tim Hortons"},
				new Restaurant { Id = 2, Name = "Subway"}
			};
		}
		public IEnumerable<Restaurant> GetAllRestaurants()
		{
			return _restaurants;
		}
	}
}
