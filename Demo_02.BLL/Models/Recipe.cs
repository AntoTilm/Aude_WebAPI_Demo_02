﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_02.BLL.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        public string? Origin { get; set; }
        public int CategoryId { get; set; }
        // Ca pourrait être cool
        //public Category Category { get; set; }

        public IEnumerable<RecipeIngredient> Ingredients { get; set;}
    }
}
