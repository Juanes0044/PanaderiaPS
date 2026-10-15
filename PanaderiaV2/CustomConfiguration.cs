using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.EntityFrameworkCore;
using PanaderiaV2.Web.Data;
using PanaderiaV2.Web.Services.Abstractions;
using PanaderiaV2.Web.Services.Implementations;

namespace PanaderiaV2.Web
{
    public static class CustomConfiguration
    {
        public static WebApplicationBuilder AddCustomConfiguration(this WebApplicationBuilder builder)
        {
            // Data Context
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));
            });

            // Automapper
            builder.Services.AddAutoMapper(typeof(Program));

            // Services
            AddServices(builder);

            // Toast Notifications
            builder.Services.AddNotyf(config => 
            { 
                config.DurationInSeconds = 10; 
                config.IsDismissable = true; 
                config.Position = NotyfPosition.BottomRight; 
            });

            return builder;
        }

        private static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IProductsService, ProductService>();
        }


        public static WebApplication AddCustomWebApplicationConfiguration(this WebApplication app)
        {
            app.UseNotyf();

            return app;
        }
    }
}