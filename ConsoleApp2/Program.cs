using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 5, 9, 7, 11 };
            FindMaxSum(list);
        }
        public static int FindMaxSum(List<int> list)
        {
           int max = list.Max();
            Console.WriteLine(max);
            Console.ReadKey();
            return max;
        }
  /*          int listItem;
            int sumOne = 0;
            int number = 0;
            
            foreach(int num in list)
            {
                
                for(int i = list.IndexOf(num)+1; i<list.Count; i++)
                {
                    listItem = list.IndexOf(num) + 1;
                    number = list[listItem];
                    sumOne = num + number;
                    list.m
                    Console.WriteLine(sumOne);
                }
                
            }
               
            Console.WriteLine(sumOne);
            Console.ReadKey();
            return sumOne;
    */
                
            
    }
}
