using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    class MenuUI
    {
        private readonly MenuRepository _cafeRepo = new MenuRepository();
        public void Run()
        {
            RunCafeMenu();
        }
    
        public void RunCafeMenu()
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the New Menu App.\n" +
                    "What would you like to do?\n" +
                    "1) Create New Menu Item.\n" +
                    "2) View current Menu Items.\n" +
                    "3) Find an item by Item Name.\n" +
                    "4) Delete a Menu Item.\n" +
                    "5) Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddNewMenuItem();
                        break;
                    case "2":
                        ViewAllItems();
                        break;
                    case "3":
                        GetItemByName();
                        break;
                    case "4":
                        DeleteItemByName();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number 1-4");
                        break;
                }





            }
        }


        public void AddNewMenuItem()
        {
            CafeMenu item = new CafeMenu();
            Console.WriteLine("What is the name of the item");
            item.MealName = Console.ReadLine();

            Console.WriteLine("What is the Meal Number");
            item.MealNumber = Convert.ToInt32(Console.ReadLine());



            Console.WriteLine("What is the items Description");
            item.Description = Console.ReadLine();

            item.Ingredients = _cafeRepo.GetIngredientList();

            Console.WriteLine("What is this Items Price");
            item.Price = Double.Parse(Console.ReadLine());

            _cafeRepo.AddNewItem(item);
            Console.WriteLine("New Menu Item has been added");
            Console.ReadKey();
        }
    
    public void ViewAllItems()
        {
            List<CafeMenu> menuItems = new List<CafeMenu>();
            menuItems = _cafeRepo.ViewMenu();
            foreach (CafeMenu item in menuItems )
            {
                Console.WriteLine($"Item Name: {item.MealName}\n");
                Console.WriteLine($"Item Description: {item.Description}\n");
                foreach(string ingredient in item.Ingredients)
                {
                    Console.WriteLine($"Ingredient: {ingredient}\n");
                }
                Console.WriteLine($"Item Name: {item.Price}\n");
            }
            Console.WriteLine("This is the crruent menu\n" +
                "Press any key to return to Main Menu.");
            Console.ReadKey();
        }

        public void GetItemByName()
        {
            Console.WriteLine("Enter the item you are looking for");
            CafeMenu item = _cafeRepo.GetByMealName(Console.ReadLine());

                Console.WriteLine($"Item Name: {item.MealName}\n");
                Console.WriteLine($"Item Description: {item.Description}\n");
                foreach (string ingredient in item.Ingredients)
                {
                    Console.WriteLine($"Ingredient: {ingredient}\n");
                }
                Console.WriteLine($"Item Name: {item.Price}\n");
            
            Console.WriteLine("This is the crruent menu\n" +
                "Press any key to return to Main Menu.");
            Console.ReadKey();
        }
    
    public void DeleteItemByName()
        {
            Console.WriteLine("What is the Name of the item you want to delete");
            _cafeRepo.DeleteItem(Console.ReadLine());
            Console.WriteLine("Item Deleted");
        }
    
    
    
    
    }
}
