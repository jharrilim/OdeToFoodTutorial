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
