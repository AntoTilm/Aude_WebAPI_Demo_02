using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = Demo_02.BLL.Models;
using Entities = Demo_02.DAL.Entities;

namespace Demo_02.BLL.Mappers
{
    public static class RecipeIngredientMapper
    {
        public static Models.RecipeIngredient ToModel(this Entities.RecipeIngredient entity)
        {
            return new Models.RecipeIngredient
            {
                IngredientId = entity.IngredientId,
                Quantity = entity.Quantity,
                Unit = entity.Unit
                //Pas d'ingrédient puisque pas de correspondant avec notre Entity
            };
        }

        public static Entities.RecipeIngredient ToEntity(this Models.RecipeIngredient model)
        {
            return new Entities.RecipeIngredient
            {
                IngredientId = model.IngredientId,
                Quantity = model.Quantity,
                Unit = model.Unit
                //On ignore l'ingrédient éventuellement présent dans model notre DAL s'enfou (donc notre Entity n'a pas la prop)
            };
        }
    }
}
