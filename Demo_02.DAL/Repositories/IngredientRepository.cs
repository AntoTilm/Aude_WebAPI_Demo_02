

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
    public class IngredientRepository : IIngredientRepository
    {
        // Pour être le plus générique possible, on va utiliser la DBConnection (au moment où on va l'injecter, on choisira le langage SQL), ça nous évitera de modifier tous nos Repositories si on veut changer de langage
        // Il est un peu plus chiant à paramétrer que SQLConnection mais au moins, il sera plus générique
        private readonly DbConnection _DbConnection;

        public IngredientRepository(DbConnection dbConnection)
        {
            _DbConnection = dbConnection;
        }

        // Mapper pour transformer les données DB en objet Entity avec le DataReader
        // IDataRecord : interface qu'implémente un DbDataReader
        public Ingredient Mapper(IDataRecord record)
        {
            return new Ingredient
            {
                Id = (int)record["Id"],
                Name = (string)record["Name"],
                IsVegetarian = (bool)record["IsVegetarian"],
                IsVegan = (bool)record["IsVegan"]
            };
        }

        public IEnumerable<Ingredient> GetAll()
        {
            // Quand on va sortir du bloc using, l'instance de notre objet command, va être automatiquement nettoyée par le Garbage, on n'en a besoin que le temps de faire notre requête
            using (DbCommand command = _DbConnection.CreateCommand())
            {
                // Création de la requête
                command.CommandText = "SELECT * FROM [Ingredient]";

                // Ouverture de la connexion
                _DbConnection.Open();
                // Récupération des données
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Va renvoyer chacune des entités créées à chaque tour de boucle dans la liste prévue en retour de fonction et à la fin de la méthode, cette liste sera automatiquement renvoyée
                        yield return Mapper(reader);
                    }
                };

                // Fermeture de la connexion
                _DbConnection.Close();
            };
        }

        public Ingredient? GetById(int id)
        {
            Ingredient? result = null;

            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Ingredient] WHERE [Id] = @Id";

                // Pour ajouter un paramètre, on doit créer un objet, le setup, puis l'ajouter aux paramètres
                //DbParameter paramId = command.CreateParameter();
                //paramId.ParameterName = "Id";
                //paramId.Value = id;
                //command.Parameters.Add(paramId);

                //Après création de la Tools :
                command.AddParamWithValue("Id", id);

                _DbConnection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    // S'il arrive à lire, on récupère la première ligne, sinon, on ne rentrera jamais dans ce if et result restera null (not found)
                    if (reader.Read())
                    {
                        result = Mapper(reader);
                    }
                };
                _DbConnection.Close();
            };

            return result;
        }

        public Ingredient Create(Ingredient entity)
        {
            Ingredient result;

            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText =
                    "INSERT INTO [Ingredient]([Name], [IsVegetarian], [IsVegan])" +
                    " OUTPUT [inserted].*" +
                    " VALUES (@Name, @IsVegetarian, @IsVegan)";

                command.AddParamWithValue("Name", entity.Name);
                command.AddParamWithValue("IsVegetarian", entity.IsVegetarian);
                command.AddParamWithValue("IsVegan", entity.IsVegan);

                _DbConnection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = Mapper(reader);
                    }
                    else
                    {
                        throw new Exception("Erreur lors de l'ajout de l'ingrédient");
                    }
                };
                _DbConnection.Close();

            };
            return result;
        }

        public bool Delete(int id)
        {
            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "DELETE FROM [Ingredient] WHERE [Id] = @Id";

                command.AddParamWithValue("Id", id);

                _DbConnection.Open();
                int nbRowDeleted = command.ExecuteNonQuery();
                _DbConnection.Close();

                return nbRowDeleted == 1;
            };
        }

        public bool Update(int id, Ingredient entity)
        {
            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText =
                    "UPDATE FROM [Ingredient]" +
                    " SET [Name] = @Name," +
                    "     [IsVegetarian] = @IsVegetarian" +
                    "     [IsVegan] = @IsVegan" +
                    " WHERE [Id] = @Id";

                command.AddParamWithValue("Id", id);
                command.AddParamWithValue("Name", entity.Name);
                command.AddParamWithValue("IsVegetarian", entity.IsVegetarian);
                command.AddParamWithValue("IsVegan", entity.IsVegan);


                _DbConnection.Open();
                int nbRowUpdated = command.ExecuteNonQuery();
                _DbConnection.Close();

                return nbRowUpdated == 1;
            }
        }


        public bool IsUsedInRecipe(int id)
        {
            bool isUsed = false;

            using (DbCommand command = _DbConnection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [MM_Recipe_Ingredient] WHERE [IngredientId] = @Id ";

                command.AddParamWithValue("Id", id);

                _DbConnection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    // Si on arrive à lire le reader, c'est qu'il y a au moins un résultat et que notre ingrédient est donc présent dans la table intermédiaire (et donc utilisé)
                    if (reader.Read())
                    {
                        isUsed = true;
                    }
                }
                _DbConnection.Close();
            }

            return isUsed; // Sera faux si on n'est jamais passé dans le reader, sinon vrai
        }


    }
}
