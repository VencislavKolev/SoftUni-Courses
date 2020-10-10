using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Contact_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> contacts = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string input = Console.ReadLine();
            while (true)
            {
                string[] commands = input.Split();
                string action = commands[0];
                int index = 0;
                if (action == "Add")
                {
                    string contactName = commands[1];
                    index = int.Parse(commands[2]);
                    if (!contacts.Contains(contactName))
                    {
                        contacts.Add(contactName);
                    }
                    else if (index >= 0 && index < contacts.Count)
                    {
                        contacts.Insert(index, contactName);
                    }
                }
                else if (action == "Remove")
                {
                    index = int.Parse(commands[1]);
                    if (index >= 0 && index < contacts.Count)
                    {
                        contacts.RemoveAt(index);
                    }
                }
                else if (action == "Export")
                {
                    int startIndex = int.Parse(commands[1]);
                    int count = int.Parse(commands[2]);
                    List<string> filteredContacts = new List<string>();
                    filteredContacts = contacts.Skip(startIndex).Take(Math.Min(count, contacts.Count)).ToList();
                    Console.WriteLine(string.Join(" ", filteredContacts));
                }
                else if (action == "Print")
                {
                    if (commands[1] == "Normal")
                    {
                        Console.WriteLine($"Contacts: {string.Join(" ", contacts)}");
                        return;
                    }
                    else
                    {
                        contacts.Reverse();
                        Console.WriteLine($"Contacts: {string.Join(" ", contacts)}");
                        return;
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
