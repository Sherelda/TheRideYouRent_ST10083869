using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheRideYouRent_ST10083869.Areas.Identity.Data;

namespace TheRideYouRent_ST10083869.Data;

public class TheRideYouRent_DBContext : IdentityDbContext<ApplicationUser>
{
    public TheRideYouRent_DBContext(DbContextOptions<TheRideYouRent_DBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
