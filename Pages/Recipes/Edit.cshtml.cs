using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using YourRecipes.Data;
using YourRecipes.Models;
using static YourRecipes.Models.Recipe;

namespace YourRecipes.Pages.Recipes
{
    public class EditModel : PageModel
    {
        private readonly IRecipeData _recipeData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Recipe Recipe { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRecipeData recipeData, IHtmlHelper htmlHelper)
        {
            _recipeData = recipeData;
            _htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? recipeId)
        {
            if (recipeId.HasValue)
            {
                Recipe = _recipeData.GetById(recipeId.Value);
            }
            else
            {
                Recipe = new Recipe();

            }

            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (Recipe == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (Recipe.Id > 0)
            {
                _recipeData.Update(Recipe);
            }
            else
            {
                _recipeData.Add(Recipe);
            }
            _recipeData.Commit();
            TempData["Message"] = "Recipe saved!";

            return RedirectToPage("./Detail", new { recipeId = Recipe.Id });
        }
    }
}
