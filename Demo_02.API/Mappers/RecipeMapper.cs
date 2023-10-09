using Demo_02.API.DTOs;
using Demo_02.BLL.Models;

namespace Demo_02.API.Mappers
{
    public static class RecipeMapper
    {
        public static RecipeDTO ToDTO(this Recipe model)
        {
            return new RecipeDTO
            {
                Id = model.Id,
                Name = model.Name,
                Origin = model.Origin,
                CategoryId = model.CategoryId,
            };
        }

        public static RecipeFullDTO ToFullDTO(this Recipe model)
        {
            return new RecipeFullDTO
            {
                Id = model.Id,
                Name = model.Name,
                Origin = model.Origin,
                CategoryId = model.CategoryId,
                Instructions = model.Instructions,
                Ingredients = model.Ingredients.Select(i => i.ToRecipeIngredientDTO())
            };
        }

        public static RecipeIngredientDTO ToRecipeIngredientDTO(this RecipeIngredient model) 
        {
            return new RecipeIngredientDTO
            {
                Id = model.IngredientId,
                Ingredient = model.Ingredient?.ToDTO(),
                Unit = model.Unit,
                Quantity = model.Quantity
            };
        }

        //TODO : Mapper pour RecipeDataDTO into model
    }
}
