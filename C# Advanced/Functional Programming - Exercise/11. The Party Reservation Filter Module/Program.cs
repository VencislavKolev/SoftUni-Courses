using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            List<string> filters = new List<string>();
            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] cmdArgs = command.Split(';').ToArray();
                string action = cmdArgs[0];
                string[] actionArgs = cmdArgs.Skip(1).ToArray();
                if (action == "Add filter")
                {
                    filters.Add(actionArgs[0] + " " + actionArgs[1]);
                }
                else if (action == "Remove filter")
                {
                    filters.Remove(actionArgs[0] + " " + actionArgs[1]);
                }
            }

            foreach (var filter in filters)
            {
                string[] filterArgs = filter.Split();
                string filterValue = filterArgs[filterArgs.Length - 1];

                if (filterArgs[0] == ("Starts"))
                {
                    names = names
                        .Where(n => !n.StartsWith(filterValue))
                        .ToList();
                }
                else if (filterArgs[0] == ("Ends"))
                {
                    names = names
                        .Where(n => !n.EndsWith(filterValue))
                        .ToList();
                }
                else if (filterArgs[0] == ("Length"))
                {
                    names = names
                        .Where(n => n.Length != int.Parse(filterValue))
                         .ToList();
                }
                else if (filterArgs[0] == ("Contains"))
                {
                    names = names
                        .Where(n => !n.Contains(filterValue))
                         .ToList();
                }
            }
            Console.WriteLine(string.Join(" ", names));
        }
    }
}