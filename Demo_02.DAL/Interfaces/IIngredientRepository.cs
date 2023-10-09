using Demo_02.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_02.DAL.Interfaces
{
    public interface IIngredientRepository : ICrud<int, Ingredient>
    {
        // Pour pouvoir supprimer un ingrédient, on devra d'abord s'assurer qu'il n'est pas présent dans la Many To Many, relié à une recette
        bool IsUsedInRecipe(int id); 
    }
}
