using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Engine
    {
        public Engine()
        {

        }
        public void Run()
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
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
            foreach (var currentPerson in persons)
            {
                Console.WriteLine(currentPerson);
            }
        }
    }
}
