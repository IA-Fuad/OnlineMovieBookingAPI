using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineMovieBookingAPI.ControllerServices;
using OnlineMovieBookingAPI.Data;

namespace OnlineMovieBookingAPI
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
            services.AddDbContext<OnlineMovieBookingContext>(opions => opions.UseSqlServer(Configuration.GetConnectionString("OnlineMovieBooking")));
            services.AddControllers().AddNewtonsoftJson();
            services.AddScoped<IBookingServices, BookingServices>();
            services.AddScoped<IHallServices, HallServices>();
            services.AddScoped<IMovieServices, MovieServices>();
            services.AddScoped<ICinemaServices, CinemaServices>();
            services.AddScoped<ICityServices, CityServices>();
            services.AddScoped<IScheduleServices, ScheduleServices>();
            services.AddScoped<IUserServices, UserServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
