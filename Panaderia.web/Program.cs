using Microsoft.EntityFrameworkCore;
using Panaderia.web;
using Panaderia.web.Data;
using Panaderia.web.Services.Abstractions;
using Panaderia.web.Services.Implementations;
using Panaderia.wed.Services.Abstractios;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.AddCustomConfiguration();

// Data Context
builder.Services.AddDbContext<DataContext>(config =>
{
    config.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));
});

//services
builder.Services.AddScoped<ISuppliersService, SuppliersService>();
builder.Services.AddScoped<IProductsService, ProductsService>();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
