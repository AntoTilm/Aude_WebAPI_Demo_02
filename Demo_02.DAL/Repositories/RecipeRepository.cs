using Demo_02.DAL.Entities;
using Demo_02.DAL.Interfaces;
using Demo_02.Tools.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_02.DAL.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DbConnection _DbConnection;
        public RecipeRepository(DbConnection dbConnection)
        {
            _DbConnection = dbConnection;
        }

        public Recipe Mapper(IDataRecord record)
        {
            return new Recipe
            {
                Id = (int)record["Id"],
                Name = (string)record["Name"],
                CategoryId = (int)record["CategoryId"],
                Instructions = (string)record["Instructions"],
                // Si le record["Origin"] renvoie le resultat NULL (db), on doit mettre notre propriété à null, sinon on prend la valeur
                Origin = record["Origin"] is DBNull ? null : (string)record["Origin"]
            };
        }

        public RecipeIngredient MapperRI(IDataRecord record)
        {
            return new RecipeIngredient
            {
                IngredientId = (int)record["IngredientId"],
                Quantity = (double)(decimal)record["Quantity"],
                Unit = (string)record["Unit"]
            };
        }

        public IEnumerable<Recipe> GetAll()
        {
            using(DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Recipe]";
                _DbConnection.Open();
                using(DbDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        yield return Mapper(reader);
                    }
                }
                _DbConnection.Close();
            };
        }

        public Recipe? GetById(int id)
        {
            Recipe? recipe = null;
            using(DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Recipe] WHERE [Id] = @Id";
                command.AddParamWithValue("Id", id);

                _DbConnection.Open();
                using(DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        recipe = Mapper(reader);
                    }
                }
                _DbConnection.Close();
            }
            return recipe;
        }

       
        public Recipe Create(Recipe entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }   
               

        public bool Update(int id, Recipe entity)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<RecipeIngredient> GetIngredients(int recipeId)
        {
            using(DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [MM_Recipe_Ingredient] WHERE [RecipeId] = @Id";
                command.AddParamWithValue("Id", recipeId);

                _DbConnection.Open();
                using(DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return MapperRI(reader);
                    }
                }
                _DbConnection.Close();
            };
        }
        public bool AddIngredient(int recipeId, RecipeIngredient ingredient)
        {
            throw new NotImplementedException();
        }
        public bool RemoveIngredient(int recipeId, int ingredientId)
        {
            throw new NotImplementedException();
        }

        public bool AddIngredients(int recipeId, IEnumerable<RecipeIngredient> ingredients)
        {
            throw new NotImplementedException();
        }

    }
}
