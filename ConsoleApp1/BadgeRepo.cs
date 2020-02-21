using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BadgeRepo
    {
        private readonly List<BadgeProp> _badgeDirectory = new List<BadgeProp>();
        private readonly Dictionary<int , List<string>> _keyCardDirectory = new Dictionary<int, List<string>>();



        public void ViewAllBadges()
        {

            foreach(KeyValuePair<int, List<string>> badge in _keyCardDirectory)
            {
                Console.WriteLine($"{badge.Key} \n{string.Join("\n", badge.Value), 10}");
            }
            Console.ReadKey();
        }

        public void AddNewBadge(BadgeProp badge)
        {
            Dictionary<int, List<string>> currentContent = _keyCardDirectory;

            currentContent.Add(badge.BadgeNumber, badge.DoorList);
        }


        public List<string> GetAccessListByID(int badgeNum)
        {
            foreach (KeyValuePair<int, List<string>> badge in _keyCardDirectory)
            {
                if (badge.Key == badgeNum)
                {
                    return badge.Value;
                }
            }
            return null;
        }


        public void AddAccessToList(string badgeID,string DoorNumber )
        {
            var doorList = GetAccessListByID(Convert.ToInt32(badgeID));

            doorList.Add(DoorNumber);

        }

        public void DeleteAccess(List<string> badge, string remove)
        {
           
            badge.Remove(remove);
            
        }















        //Code was just used for the initial Seed info. I know i could of just put it into a dict. to save code, but i had more fun doind it this way.



        public void MakeDic()
        {
            foreach (BadgeProp badge in _badgeDirectory)
            {
                _keyCardDirectory.Add(badge.BadgeNumber, badge.DoorList);
            }
        }
        public void AddBadge(BadgeProp badge)
        {
            _badgeDirectory.Add(badge);
        }



    }
}
