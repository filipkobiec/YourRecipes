using System.ComponentModel.DataAnnotations;

namespace YourRecipes.Models
{
    public class Recipe
    {
        public enum CuisineType
        {
            None,
            Italian,
            Indian,
            Mexican
        }
        public Guid Id { get; set; }

        [Required, StringLength(80)]
        public string Title { get; set; }

        [Required, StringLength(150)]
        public string ShortDescription { get; set; }

        [Required, StringLength(1000)]
        public string Descritption { get; set; }


        [Required]
        public CuisineType Cuisine { get; set; }
    }
}
