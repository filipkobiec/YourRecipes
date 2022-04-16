using YourRecipes.Models;

namespace YourRecipes.Data
{
    public interface IRecipeData
    {
        IEnumerable<Recipe> GetRecipeByTitle(string title);
        Recipe GetById(Guid id);
        Recipe Update(Recipe updateRecipe);
        int Commit();
    }
}
