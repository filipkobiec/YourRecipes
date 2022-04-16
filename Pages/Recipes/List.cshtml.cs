using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YourRecipes.Data;
using YourRecipes.Models;

namespace YourRecipes.Pages.Recipes
{
    public class ListModel : PageModel
    {
        private readonly IRecipeData _recipeData;
        public IEnumerable<Recipe> Recipes { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public ListModel(IRecipeData recipeData)
        {
            _recipeData = recipeData;
        }
        public void OnGet()
        {
            Recipes = _recipeData.GetRecipeByTitle(SearchTerm);
        }
    }
}
