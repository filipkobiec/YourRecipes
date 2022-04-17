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
                new Recipe{Id = 1, Title = "Pizza", Cuisine=CuisineType.Italian, ShortDescription="Delicious pizza"},
                new Recipe{Id = 2, Title = "Pizza1", Cuisine=CuisineType.Italian, ShortDescription="Delicious pizza1"},
                new Recipe{Id = 3, Title = "Pizza2", Cuisine=CuisineType.Italian, ShortDescription="Delicious pizza2"}
            };
        }

        public Recipe Add(Recipe newRecipe)
        {
            _recipes.Add(newRecipe);
            newRecipe.Id = _recipes.Max(r => r.Id) + 1;
            return newRecipe;
        }

        public int Commit()
        {
            return 0;
        }

        public Recipe Delete(int Id)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Id == Id);

            if (recipe != null)
            {
                _recipes.Remove(recipe);
            }

            return recipe;
        }

        public Recipe GetById(int id) => _recipes.SingleOrDefault(r => r.Id == id);

        public IEnumerable<Recipe> GetRecipeByTitle(string title = null) => _recipes.Where(t => string.IsNullOrEmpty(title) || t.Title.StartsWith(title));

        public Recipe Update(Recipe updatedRecipe)
        {
            var recipe = GetById(updatedRecipe.Id);

            if (recipe != null)
            {
                recipe.Title = updatedRecipe.Title;
                recipe.Descritption = updatedRecipe.Descritption;
                recipe.Cuisine = updatedRecipe.Cuisine;
                recipe.ShortDescription = updatedRecipe.ShortDescription;
            }

            return recipe;
        }

    }
}
