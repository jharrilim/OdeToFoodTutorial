using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OdeToFoodTutorial.Entities
{
    public class OdeToFoodDbContext : IdentityDbContext<User>
    {
		public DbSet<Restaurant> Restaurants { get; set; }


		public OdeToFoodDbContext(DbContextOptions options) : base(options)
		{

		}
    }
}
