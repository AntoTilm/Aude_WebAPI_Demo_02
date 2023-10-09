using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = Demo_02.BLL.Models;
using Entities = Demo_02.DAL.Entities;

namespace Demo_02.BLL.Mappers
{
    public static class RecipeMapper
    {
        public static Models.Recipe ToModel(this Entities.Recipe entity)
        {
            return new Models.Recipe
            {
                Id = entity.Id,
                Name = entity.Name,
                Instructions = entity.Instructions,
                CategoryId = entity.CategoryId,
                Origin = entity.Origin,
                // On setupera les ingrédients plus tard
            };
        }

        public static Entities.Recipe ToEntity(this Models.Recipe model)
        {
            return new Entities.Recipe
            {
                Id = model.Id,
                Name = model.Name,
                Instructions = model.Instructions,
                CategoryId = model.CategoryId,
                Origin = model.Origin
            };
        }
    }
}
