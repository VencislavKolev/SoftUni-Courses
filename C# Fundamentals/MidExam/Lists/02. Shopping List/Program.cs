using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> products = Console.ReadLine().Split('!').ToList();
            string input = "";
            while ((input = Console.ReadLine()) != "Go Shopping!")
            {
                string[] commands = input.Split();
                string action = commands[0];
                string product = commands[1];
                if (action == "Urgent")
                {
                    if (!products.Contains(product))
                    {
                        products.Insert(0, product);
                    }
                }
                else if (action == "Unnecessary")
                {
                    if (products.Contains(product))
                    {
                        products.Remove(product);
                    }
                }
                else if (action == "Correct")
                {
                    if (products.Contains(product))
                    {
                        string newName = commands[2];
                        int index = products.IndexOf(product);
                        products.Insert(index, newName);
                        products.Remove(product);
                    }
                }
                else if (action == "Rearrange")
                {
                    if (products.Contains(product))
                    {
                        products.Remove(product);
                        products.Add(product);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", products));
        }
    }
}
