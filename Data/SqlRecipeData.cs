using Microsoft.EntityFrameworkCore;
using YourRecipes.Models;

namespace YourRecipes.Data
{
    public class SqlRecipeData : IRecipeData
    {
        private readonly YourRecipesDbContext _dbContext;

        public SqlRecipeData(YourRecipesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Recipe Add(Recipe newRecipe)
        {
            _dbContext.Recipes.Add(newRecipe);
            return newRecipe;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public Recipe Delete(int Id)
        {
            var recipe = GetById(Id);
            if (recipe != null)
            {
                _dbContext.Recipes.Remove(recipe);
            }
            return recipe;
        }

        public Recipe GetById(int id)
        {
            return _dbContext.Recipes.Find(id);
        }

        public IEnumerable<Recipe> GetRecipeByTitle(string title)
        {
            return _dbContext.Recipes.Where(x => x.Title == title || string.IsNullOrEmpty(title)).OrderBy(x => x.Title);
        }

        public Recipe Update(Recipe updatedRecipe)
        {
            var entity = _dbContext.Recipes.Attach(updatedRecipe);
            entity.State = EntityState.Modified;
            return updatedRecipe;
        }
    }
}
