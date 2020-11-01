using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Team team = new Team("SoftUni");
            var persons = new List<Person>();

            var lines = int.Parse(Console.ReadLine());
            Person person = null;
            for (int i = 0; i < lines; i++)
            {
                try
                {
                    var cmdArgs = Console.ReadLine().Split();
                    person = new Person(cmdArgs[0],
                                           cmdArgs[1],
                                           int.Parse(cmdArgs[2]),
                                           decimal.Parse(cmdArgs[3]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                persons.Add(person);
            }
            foreach (Person currentPerson in persons)
            {
                team.AddPlayer(currentPerson);
            }
            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
