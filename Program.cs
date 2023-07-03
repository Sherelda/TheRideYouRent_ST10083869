using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheRideYouRent_ST10083869.Areas.Identity.Data;
using TheRideYouRent_ST10083869.Data;
namespace TheRideYouRent_ST10083869
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("TheRideYouRent_DBContextConnection") ?? throw new InvalidOperationException("Connection string 'TheRideYouRent_DBContextConnection' not found.");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<TheRideYouRent_ST10083869.Models.TheRideYouRentContext>();

            builder.Services.AddDbContext<TheRideYouRent_ST10083869.Data.TheRideYouRent_DBContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<TheRideYouRent_DBContext>();

            builder.Services.AddRazorPages();
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Car}/{action=Index}/{id?}");
            app.MapRazorPages();
            app.Run();
          
        }
    }
}