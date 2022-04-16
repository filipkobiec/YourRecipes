using YourRecipes.Models;

namespace YourRecipes.Data
{
    public interface IRecipeData
    {
        IEnumerable<Recipe> GetAll();
    }
}
