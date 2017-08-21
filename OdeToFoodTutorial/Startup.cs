using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using OdeToFoodTutorial.Services;
using OdeToFoodTutorial.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace OdeToFoodTutorial
{
    public class Startup
    {
		public IConfiguration Configuration { get; set; }

		public Startup(IHostingEnvironment environment)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(environment.ContentRootPath)
				.AddJsonFile("appsettings.json")
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}
        
		// This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddMvc();
			services.AddSingleton(Configuration);
			services.AddSingleton<IGreeter, Greeter>();
			services.AddScoped<IRestaurantData, SqlRestaurantData>();
			services.AddDbContext<OdeToFoodDbContext>(options => 
				options.UseSqlServer(Configuration.GetConnectionString("OdeToFood")));
			services.AddIdentity<User, IdentityRole>()
				.AddEntityFrameworkStores<OdeToFoodDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure
			(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IGreeter greeter)
        {
			loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
			else
			{
				app.UseExceptionHandler(new ExceptionHandlerOptions()
				{
					ExceptionHandler = context => context.Response.WriteAsync("Whoops")
				});
			}

			app.UseFileServer();

			app.UseNodeModules(env.ContentRootPath);

			// Deprecated: app.UseIdentity();
			app.UseAuthentication();

			app.UseMvc(ConfigureRoutes);

			app.Run(ctx => ctx.Response.WriteAsync("Not Found"));
        }

		private void ConfigureRoutes(IRouteBuilder routeBuilder)
		{
			routeBuilder.MapRoute("Default","{controller=Home}/{action=Index}/{id?}");
		}
	}
}
