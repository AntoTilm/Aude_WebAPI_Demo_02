using Demo_02.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_02.BLL.Interfaces
{
    public interface IRecipeService
    {
        public IEnumerable<Recipe> GetAll();
        public Recipe? GetById(int id);

        public Recipe Create(Recipe recipe);
        public bool Update(int id, Recipe recipe);
        public bool Delete(int id);
        public bool AddIngredient(int recipeId, RecipeIngredient ingredient);
        public bool RemoveIngredient(int recipeId, int ingredientId);
        public bool AddIngredients(int recipeId, IEnumerable<RecipeIngredient> ingredients);
    }
}
