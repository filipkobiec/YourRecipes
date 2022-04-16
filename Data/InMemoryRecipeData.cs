using System.Linq;
using YourRecipes.Models;
using static YourRecipes.Models.Recipe;

namespace YourRecipes.Data
{
    public class InMemoryRecipeData : IRecipeData
    {
        List<Recipe> _recipes;

        public InMemoryRecipeData()
        {
            _recipes = new List<Recipe>()
            {
                new Recipe{Id = Guid.NewGuid(), Title = "Pizza", Cuisine=CuisineType.Italian, ShortDescription="Delicious pizza"},
                new Recipe{Id = Guid.NewGuid(), Title = "Pizza1", Cuisine=CuisineType.Italian, ShortDescription="Delicious pizza1"},
                new Recipe{Id = Guid.NewGuid(), Title = "Pizza2", Cuisine=CuisineType.Italian, ShortDescription="Delicious pizza2"}
            };
        }

        public int Commit()
        {
            return 0;
        }

        public Recipe GetById(Guid id) => _recipes.SingleOrDefault(r => r.Id == id);

        public IEnumerable<Recipe> GetRecipeByTitle(string title = null) => _recipes.Where(t => string.IsNullOrEmpty(title) || t.Title.StartsWith(title));

        public Recipe Update(Recipe updateRecipe)
        {
            var recipe = GetById(updateRecipe.Id);

            if (recipe != null)
            {
                recipe.Title = updateRecipe.Title;
                recipe.Descritption = updateRecipe.Descritption;
                recipe.Cuisine = updateRecipe.Cuisine;
                recipe.ShortDescription = updateRecipe.ShortDescription;
            }

            return recipe;
        }

    }
}
