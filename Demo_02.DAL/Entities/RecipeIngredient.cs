using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_02.DAL.Entities
{
    public class RecipeIngredient
    {
        public int IngredientId { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
    }
}
