using Demo_02.API.DTOs;
using Demo_02.BLL.Models;

namespace Demo_02.API.Mappers
{
    public static class IngredientMapper
    {
        // Un Mapper Model (BLL) → IngredientDTO
        public static IngredientDTO ToDTO (this Ingredient ingredient)
        {
            return new IngredientDTO
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                IsVegetarian = ingredient.IsVegetarian,
                IsVegan = ingredient.IsVegan
            };
        }
        // Un Mapper IngredientDTO → Model (BLL)
        public static Ingredient ToModel (this IngredientDataDTO ingredient)
        {
            return new Ingredient
            {
                Id = 0,
                Name = ingredient.Name,
                // - ?? → Coalesce : Si la valeur à gauche est non null, on la prend elle, sinon, on prend la valeur à droite
                IsVegetarian = ingredient.IsVegetarian ?? false,
                IsVegan = ingredient.IsVegan ?? false
            };

        }
    }
}
