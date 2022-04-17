using YourRecipes.Models;

namespace YourRecipes.Data
{
    public interface IRecipeData
    {
        IEnumerable<Recipe> GetRecipeByTitle(string title);
        Recipe GetById(int id);
        Recipe Update(Recipe updateRecipe);
        Recipe Add(Recipe newRecipe);
        Recipe Delete(int Id);
        int Commit();
    }
}
