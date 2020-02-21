using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{  
    class CafeMenu
    {
        public CafeMenu() { }
        public CafeMenu(string mealName, string description, List<string> ingredient, double price )
        {
            MealName = mealName;
            Description = description;
            Ingredients = ingredient;
            Price = price;
        }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public double Price { get; set; }

    
        
    }
}
