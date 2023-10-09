using Demo_02.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_02.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category? GetById(int id);
    }
}
