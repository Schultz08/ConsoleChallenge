using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeAccess
{
    class BadgeUI
    {
    private readonly BadgeRepo _repoDirectory = new BadgeRepo();

        public void Run()
        {
            Seed();
            _repoDirectory.MakeDic();
            RunMenu();
        }


        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Badge Access.\n" +
                    "What would you like to do?\n" +
                    "1) View all current Badges.\n" +
                    "2) Add New Badge\n" +
                    "3) Update Badge\n" +
                    "4) Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":ViewBadges();
                        break;
                    case "2":AddNewBadge();
                        break;
                    case "3":UpdateAccess();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number 1-4");
                        break;
                }

            }
        }




        private void ViewBadges()
        {
            _repoDirectory.ViewAllBadges();
        }

        private void AddNewBadge()
        {
            BadgeProp badge = new BadgeProp();
            badge.DoorList = new List<string>();
            bool isAdding = true;
            string yesNo;

            Console.WriteLine("What is the Badge ID number");
            badge.BadgeNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What door access do you want to add?(One door at a time)");
            badge.DoorList.Add(Console.ReadLine());
            

           // _repoDirectory.NewListOfDoors(badge, doorNum);

            while (isAdding)
            {

                Console.WriteLine("Do you want to add another door? Y/N");
                yesNo = Console.ReadLine();

                if (yesNo == "yes" || yesNo == "y")
                {
                    Console.WriteLine("What door do you want to add?(One door at a time)");
                    badge.DoorList.Add(Console.ReadLine());
                }
                else
                {
                    _repoDirectory.AddNewBadge(badge);
                    isAdding = false;
                }
            }
        }
        private void UpdateAccess()
        {
            bool isUpdating = true;
            Console.WriteLine("What Badge ID do you want to Update?");
            string badgeID = Console.ReadLine();

            var currentAccess = _repoDirectory.GetAccessListByID(Convert.ToInt32(badgeID));

            Console.WriteLine($"{badgeID}has Access to: {string.Join(",", currentAccess)}");

            Console.WriteLine("Do you want to do?\n" +
                "1)Remove Access\n" +
                "2)Add Access");

            string userInput = Console.ReadLine();
        while (isUpdating)
            {
                if(userInput == "1")
                {
                    Console.WriteLine("What door access do you want to remove?");
                    string remove = Console.ReadLine();
                    _repoDirectory.DeleteAccess(currentAccess, remove);
                    isUpdating = false;
                }
                else
                {
                    string yesNo;
                    Console.WriteLine("What Access do you want to add?");
                    string doorNum = Console.ReadLine();

                    Console.WriteLine("Do you want to add another access?");
                    yesNo = Console.ReadLine();

                    while (yesNo.ToLower() != "no" || yesNo.ToLower() != "n")
                    {
                         Console.WriteLine("Do you want to add another door? Y/N");
                         yesNo = Console.ReadLine();

                        if(yesNo.ToLower() == "yes" || yesNo.ToLower() == "y")
                        {
                            Console.WriteLine("What door do you want to add?(One door at a time)");
                            doorNum = Console.ReadLine();
                          _repoDirectory.AddAccessToList(badgeID, doorNum);
                        }
                        else
                        {
                            isUpdating = false;
                            break;
                        }
                    }
                }
            }
        }





        private void Seed()
        {
            List<string> listOne = new List<string> { "A7", "A4", "A2" };
            List<string> listTwo = new List<string> { "A55", "A22", "A8" };
            BadgeProp one = new BadgeProp(12345, listOne);
            _repoDirectory.AddBadge(one);
            BadgeProp two = new BadgeProp(54321, listTwo);
            _repoDirectory.AddBadge(two);
        }

    }
}
