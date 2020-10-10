using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invertory = Console.ReadLine().Split(", ").ToList();
            string input = "";
            while ((input = Console.ReadLine()) != "Craft!")
            {
                string[] tokens = input.Split(" - ");
                string action = tokens[0];
                string item = tokens[1];
                if (action == "Collect")
                {
                    if (!invertory.Contains(item))
                    {
                        invertory.Add(item);
                    }
                }
                else if (action == "Drop")
                {
                    if (invertory.Contains(item))
                    {
                        invertory.Remove(item);
                    }
                }
                else if (action == "Combine Items")
                {
                    string[] oldNewItems = item.Split(':');
                    string oldIitem = oldNewItems[0];
                    string newItem = oldNewItems[1];
                    if (invertory.Contains(oldIitem))
                    {
                        int indexOfOld = invertory.IndexOf(oldIitem);
                        invertory.Insert(indexOfOld + 1, newItem);
                    }
                }
                else if (action == "Renew")
                {
                    if (invertory.Contains(item))
                    {
                        invertory.Remove(item);
                        invertory.Add(item);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", invertory));
        }
    }
}
