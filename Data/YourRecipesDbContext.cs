using Microsoft.EntityFrameworkCore;
using YourRecipes.Models;

namespace YourRecipes.Data
{
    public class YourRecipesDbContext : DbContext
    {
        public YourRecipesDbContext(DbContextOptions<YourRecipesDbContext> options) : base(options)
        {

        }
        public DbSet<Recipe> Recipes { get; set; }
    }
}
