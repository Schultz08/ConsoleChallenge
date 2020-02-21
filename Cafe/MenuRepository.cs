using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class MenuRepository
    {
        private readonly List<CafeMenu> _cafeDirectory = new List<CafeMenu>();

        public void AddNewItem(CafeMenu item)
        {
            _cafeDirectory.Add(item);
        }


        public List<CafeMenu> ViewMenu()
        {
            return _cafeDirectory;
        }

        public bool DeleteItem(string item)
        {
            CafeMenu foundMeal = GetByMealName(item);
            bool result = _cafeDirectory.Remove(foundMeal);
            return result; 
        }

        public CafeMenu GetByMealName(string meal)
        {
            foreach(CafeMenu item in _cafeDirectory)
            {
                if (item.MealName.ToLower() == meal.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        public List<string> GetIngredientList()
        {
            List<string> newItem = new List<string>();
            Console.WriteLine("How many ingredients are in this item");

            int itemCount = Int32.Parse(Console.ReadLine());

            Console.WriteLine("What is the first ingredient you want to add");
            newItem.Add(Console.ReadLine());
            itemCount--;

            while (itemCount > 0)
            {
                Console.WriteLine("What is the next Ingredient");
                newItem.Add(Console.ReadLine());
                itemCount--;
            }
            return newItem;
        }
    }
}
