using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OdeToFoodTutorial.Entities
{
    public class OdeToFoodDbContext : DbContext
    {
		public DbSet<Restaurant> Restaurants { get; set; }

		public OdeToFoodDbContext(DbContextOptions options) : base(options)
		{

		}
    }
}
