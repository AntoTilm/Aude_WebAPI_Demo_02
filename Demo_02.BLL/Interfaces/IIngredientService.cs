using Demo_02.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_02.BLL.Interfaces
{
    public interface IIngredientService
    {
        public IEnumerable<Ingredient> GetAll();
        public Ingredient? GetById(int id);
        public Ingredient Insert(Ingredient ingredient);
        public bool Delete(int id);
    }
}
