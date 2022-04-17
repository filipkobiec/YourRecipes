using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YourRecipes.Models;

namespace YourRecipes.Data
{
    public class YourRecipesDbContext : IdentityDbContext<IdentityUser>
    {
        public YourRecipesDbContext(DbContextOptions<YourRecipesDbContext> options) : base(options)
        {

        }
        public DbSet<Recipe> Recipes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
