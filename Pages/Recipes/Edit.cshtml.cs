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
        public IActionResult OnGet(Guid recipeId)
        {
            Recipe = _recipeData.GetById(recipeId);
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (Recipe == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _recipeData.Update(Recipe);
                _recipeData.Commit();
            }
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }
    }
}
