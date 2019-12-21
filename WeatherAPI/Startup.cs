using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Permissions;
using GoogleMapsAPI;
using Abstract;
using OpenWeatherMapClasses;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));
			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationDbContext>();
			services.AddControllersWithViews();
			services.AddRazorPages();

			services.AddControllers();

			services.AddApiVersioning(o => {
				o.ReportApiVersions = true;
				o.AssumeDefaultVersionWhenUnspecified = true;
				o.DefaultApiVersion = new ApiVersion(1, 0);
			});


#if DEBUG
			IMvcBuilder mvc = services.AddControllersWithViews();
			IMvcBuilder mvcpages = services.AddRazorPages();
			mvc.AddRazorRuntimeCompilation();
			mvcpages.AddRazorRuntimeCompilation();
#endif

			ApiKeys keys = Configuration.GetSection("ApiKeys").Get<ApiKeys>();

			services.AddSingleton(keys);
			services.AddSingleton<ITimeZoneAPI, GTimeZoneAPI>((x)=>new GTimeZoneAPI(new APISetup {APIKey=keys.GoogleAPIKey}));
			services.AddSingleton<IWeatherAPI, OWMAPI>((x) => new OWMAPI(new APISetup { APIKey = keys.OpenWeatherMapsKey }));
			services.AddSingleton<IElevationAPI, GElevationAPI>((x) => new GElevationAPI(new APISetup { APIKey = keys.GoogleAPIKey }));
			services.AddSingleton<WeatherAPI.Classes.Weather>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
			});
		}
	}
}
