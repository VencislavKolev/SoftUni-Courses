using System;
using P04.BorderControl.Models;
using System.Collections.Generic;

namespace P04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> identifiables = new List<IIdentifiable>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                IIdentifiable identifiable = null;
                string[] cmdArgs = command.Split();
                if (cmdArgs.Length == 2)
                {
                    string model = cmdArgs[0];
                    string id = cmdArgs[1];
                    identifiable = new Robot(model, id);

                }
                else if (cmdArgs.Length == 3)
                {
                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];
                    identifiable = new Citizen(name, age, id);
                }
                identifiables.Add(identifiable);
            }
            string fakeIdsValue = Console.ReadLine();
            foreach (var identifiable in identifiables)
            {
                string currentId = identifiable.Id;
                if (currentId.Length >= fakeIdsValue.Length)
                {
                    string lastDigitsOfCurrentId = currentId.Substring(currentId.Length - fakeIdsValue.Length);
                    if (lastDigitsOfCurrentId == fakeIdsValue)
                    {
                        Console.WriteLine(currentId);
                    }
                }

            }
        }
    }
}
