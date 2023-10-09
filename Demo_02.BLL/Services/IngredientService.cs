using Demo_02.BLL.CustomExceptions;
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
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _IngredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository )
        {
            _IngredientRepository = ingredientRepository;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            // Notre GetAll() du Repository (DAL) renvoie une liste d'Entity
            // Notre GetAll() du Service (BLL) doit renvoyer une liste de Model
            // Nous allons selectionner toutes les Entity (Select()) et les transformer en Model grâce au mapper
            return _IngredientRepository.GetAll().Select(i => i.ToModel() );
            //return _IngredientRepository.GetAll().Select(IngredientMapper.ToModel); //Marche aussi
        }

        public Ingredient? GetById(int id)
        {
            return _IngredientRepository.GetById(id)?.ToModel();
        }

        public Ingredient Insert(Ingredient ingredient)
        {
            return _IngredientRepository.Create(ingredient.ToEntity()).ToModel();
        }

        public bool Delete(int id)
        {
            // Vérifier s'il est utilisé dans une recette
            if (_IngredientRepository.IsUsedInRecipe(id))
            {
                throw new AlreadyUsedException();
            }

            // Si pas, on peut tenter la suppression
            bool deleted = _IngredientRepository.Delete(id);
            if(!deleted)
            {
                throw new NotFoundException();
            }

            return deleted;

        }
    }
}
