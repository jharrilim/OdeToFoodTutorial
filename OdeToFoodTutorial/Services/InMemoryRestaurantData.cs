using OdeToFoodTutorial.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFoodTutorial.Services
{

	public interface IRestaurantData
	{
		IEnumerable<Restaurant> GetAllRestaurants();
		Restaurant Get(int id);
		Restaurant Add(Restaurant restaurant);
	}

	public class InMemoryRestaurantData : IRestaurantData
	{
		private static List<Restaurant> _restaurants;

	    static InMemoryRestaurantData()
		{
			_restaurants = new List<Restaurant>
			{
				new Restaurant { Id = 0, Name = "McDonalds"},
				new Restaurant { Id = 1, Name = "Tim Hortons"},
				new Restaurant { Id = 2, Name = "Subway"}
			};
		}

		public Restaurant Add(Restaurant restaurant)
		{
			restaurant.Id = _restaurants.Max(r => r.Id) + 1;
			_restaurants.Add(restaurant);
			return restaurant;
		}

		public Restaurant Get(int id)
		{
			return _restaurants.FirstOrDefault(r => r.Id == id);
		}

		public IEnumerable<Restaurant> GetAllRestaurants()
		{
			return _restaurants;
		}
	}
}
