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
        public IEnumerable<Recipe> GetAll()
        {
            return _recipes.OrderBy(r => r.Title);
        }
    }
}
