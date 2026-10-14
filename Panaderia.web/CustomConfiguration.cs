using Microsoft.EntityFrameworkCore;
using Panaderia.web.Data;
using Panaderia.web.Services.Abstractions;
using Panaderia.web.Services.Implementations;

namespace Panaderia.web
{
    public static class CustomConfiguration
    {
        public static WebApplicationBuilder AddCustomConfiguration(this WebApplicationBuilder builder)
        {
            //Data Context
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));
            });

            //Automapper
            builder.Services.AddAutoMapper(typeof(Program));

            //Services
            AddServices(builder);

            return builder;


        }

        private static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IProductsService, ProductsService>();
        }

    }
}
