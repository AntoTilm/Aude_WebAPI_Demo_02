using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Nos classes portant le même noms dans les Models de la BLL et les Entities de la DAL, nous devons mettre un alias sur les using, pour savoir de quel Ingredient qu'on parle
using Models = Demo_02.BLL.Models;
using Entities = Demo_02.DAL.Entities;


namespace Demo_02.BLL.Mappers
{
    public static class IngredientMapper
    {
        // Ici notre Entity Ingredient et notre Model Ingredient ont la même tronche, dans pas mal de cas, les deux seront différents
        public static Models.Ingredient ToModel(this Entities.Ingredient entity)
        {
            return new Models.Ingredient
            {
                Id = entity.Id,
                Name = entity.Name,
                IsVegetarian = entity.IsVegetarian,
                IsVegan = entity.IsVegan,
            };
        }

        public static Entities.Ingredient ToEntity(this Models.Ingredient model)
        {
            return new Entities.Ingredient
            {
                Id = model.Id,
                Name = model.Name,
                IsVegetarian = model.IsVegetarian,
                IsVegan = model.IsVegan,
            };
        }
    }
}
