namespace Demo_02.API.DTOs
{
    // Pour le GetAll (Osef des ingrédients)
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Origin { get; set; }
        public int CategoryId { get; set; }
    }

    //Pour le GetById -> On va renvoyer la liste des ingrédients pour une recette
    public class RecipeFullDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        public string? Origin { get; set; }
        public int CategoryId { get; set; }
        // public Category Category { get; set;}
        public IEnumerable<RecipeIngredientDTO> Ingredients { get; set; }
    }

    public class RecipeIngredientDTO
    {
        public int Id { get; set; }
        public IngredientDTO? Ingredient { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;

    }

    // TODO : RecipeDTO pour ajouter/modifier une Recipe
    public class RecipeDataDTO
    {

    }
}
