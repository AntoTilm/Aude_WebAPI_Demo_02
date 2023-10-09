using System.ComponentModel.DataAnnotations;

namespace Demo_02.API.DTOs
{
    // Ingredient tel qu'il est attendu en résultat de requête
    public class IngredientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
    }

    // Ingredient tel qu'il est attendu pour ajouter/modifier des données
    public class IngredientDataDTO
    {
        [Required]
        //[MaxLength(50)]
        //[MinLength(2)]
        // Combinaison des deux en un :
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        public bool? IsVegetarian { get; set; }
        public bool? IsVegan { get; set; }
    }
}
