using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proyecto_Hospital.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "login",
        pattern: "{controller=Login}/{action=Login}/{id?}");
        

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Otros servicios...

    // Configuración del DbContext
    services.AddDbContext<HospitalDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("conexion")));

    // Configuración del servicio NewsService con inyección de dependencias
    var apiKey = "f73ddfb5c14c45dca62858804af76930";
    services.AddScoped<INewsServiceApiClient>(_ => new NewsApiClientWrapper(apiKey));
    services.AddAuthorization();
    services.AddControllers();
    services.AddControllersWithViews();
    services.AddScoped<NewsService>();

    // Otros servicios...
}
