using System;
using System.Linq;
using System.Collections.Generic;
using P05.BirthdayCelebrations.Models;

namespace P05.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                IBirthable birthable = null;
                string[] cmdArgs = command.Split();
                string type = cmdArgs[0];
                string name = cmdArgs[1];
                if (type == "Citizen")
                {
                    int age = int.Parse(cmdArgs[2]);
                    string id = cmdArgs[3];
                    string birthdate = cmdArgs[4];
                    birthable = new Citizen(name, age, id, birthdate);

                }
                else if (type == "Pet")
                {
                    string birthdate = cmdArgs[2];
                    birthable = new Pet(name, birthdate);
                }
                if (birthable != null)
                {
                    birthables.Add(birthable);
                }
            }
            string year = Console.ReadLine();
            if (birthables.Any())
            {
                bool hasYear = false;
                foreach (var birthable in birthables)
                {
                    string currBirthDate = birthable.BirthDate;
                    string currYear = currBirthDate.Substring(currBirthDate.Length - 4);
                    if (currYear == year)
                    {
                        hasYear = true;
                        Console.WriteLine(currBirthDate);
                    }
                }
                if (hasYear == false)
                {
                    Console.WriteLine("<empty output>");
                }
            }
        }
    }
}
