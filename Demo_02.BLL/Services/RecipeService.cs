using Demo_02.BLL.Interfaces;
using Demo_02.BLL.Mappers;
using Demo_02.BLL.Models;
using Demo_02.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_02.BLL.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _RecipeRepository;
        private readonly IIngredientRepository _IngredientRepository;

        public RecipeService(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
        {
            _RecipeRepository = recipeRepository;
            _IngredientRepository = ingredientRepository;
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _RecipeRepository.GetAll().Select(r => r.ToModel());
        }

        public Recipe? GetById(int id)
        {
            Recipe? recipe = _RecipeRepository.GetById(id)?.ToModel();
            if(recipe is not null)
            {
                // On va devoir ajouter les ingrédients
                IEnumerable<RecipeIngredient> recipeIngredients = _RecipeRepository.GetIngredients(id)
                    //On joint la "table" Ingredient grâce à notre GetAll() et le lien entre les deux se fait via [MM]IngredientId = [Ingredient]Id, on obtient une lambda avec en premier param un RecipeIngredient (Entity) et en 2ème, l'ingrédient (Entity) correspondant, à la fin, on renvoie RecipeIngredient (Model) qui contient les deux
                    .Join(_IngredientRepository.GetAll(), ri => ri.IngredientId, i => i.Id, (ri, i) =>
                    {
                        //ri contient un RecipeIngredient entity
                        RecipeIngredient res = ri.ToModel();
                        //i contient l'ingrédient associé au ri, entity
                        res.Ingredient = i.ToModel();
                        return res;
                    });
                recipe.Ingredients = recipeIngredients;
            }

            return recipe;
        }

        public Recipe Create(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool AddIngredient(int recipeId, RecipeIngredient ingredient)
        {
            throw new NotImplementedException();
        }

        public bool AddIngredients(int recipeId, IEnumerable<RecipeIngredient> ingredients)
        {
            throw new NotImplementedException();
        }
        public bool RemoveIngredient(int recipeId, int ingredientId)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
