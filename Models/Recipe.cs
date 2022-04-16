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
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Descritption { get; set; }
        public string Image { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
