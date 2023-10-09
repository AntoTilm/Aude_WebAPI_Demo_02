using Demo_02.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_02.DAL.Interfaces
{
    public interface IRecipeRepository : ICrud<int, Recipe>
    {
        // A partir d'une recette, on va vouloir récupérer la liste des ingrédients et leurs quantités/unité
        IEnumerable<RecipeIngredient> GetIngredients(int recipeId);

        // A partir d'une recette, on va vouloir ajouter ou supprimer un ingrédient (et sa quantité/unité)
        bool AddIngredients(int recipeId, IEnumerable<RecipeIngredient> ingredients);
        bool AddIngredient(int recipeId, RecipeIngredient ingredient);
        bool RemoveIngredient(int recipeId, int ingredientId);
    }
}
