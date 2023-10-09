using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_02.DAL.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
    }
}
