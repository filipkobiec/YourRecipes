using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YourRecipes.Data;
using YourRecipes.Models;

namespace YourRecipes.Pages.Recipes
{
    public class DetailModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        private readonly IRecipeData _recipeData;

        public DetailModel(IRecipeData recipeData)
        {
            _recipeData = recipeData;
        }
        public Recipe Recipe { get; set; }
        public IActionResult OnGet(int recipeId)
        {
            Recipe = _recipeData.GetById(recipeId);
            if (Recipe == null)
                return RedirectToPage("./NotFound");
            return Page();
        }
    }
}
