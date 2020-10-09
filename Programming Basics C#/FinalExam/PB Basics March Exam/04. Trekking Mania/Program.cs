using System;

namespace _04._Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGroups = int.Parse(Console.ReadLine());
            int totalPeople = 0;
            int peopleForMusala = 0;
            int peopleForMonblan = 0;
            int peopleForKilimandjaro = 0;
            int peopleForK2 = 0;
            int peopleForEverest = 0;
            for (int group = 1; group <= numberOfGroups; group++)
            {
                int numberOfPeopleInTheGroup = int.Parse(Console.ReadLine());
                totalPeople += numberOfPeopleInTheGroup;
                if (numberOfPeopleInTheGroup <= 5)
                {
                    peopleForMusala += numberOfPeopleInTheGroup;
                }
                else if (numberOfPeopleInTheGroup > 5 && numberOfPeopleInTheGroup <= 12)
                {
                    peopleForMonblan += numberOfPeopleInTheGroup;
                }
                else if (numberOfPeopleInTheGroup > 12 && numberOfPeopleInTheGroup <= 25)
                {
                    peopleForKilimandjaro += numberOfPeopleInTheGroup;
                }
                else if (numberOfPeopleInTheGroup > 25 && numberOfPeopleInTheGroup <= 40)
                {
                    peopleForK2 += numberOfPeopleInTheGroup;
                }
                else if (numberOfPeopleInTheGroup > 40)
                {
                    peopleForEverest += numberOfPeopleInTheGroup;
                }
            }
            Console.WriteLine($"{(peopleForMusala * 1.0 / totalPeople) * 100:f2}%");
            Console.WriteLine($"{(peopleForMonblan * 1.0 / totalPeople) * 100:f2}%");
            Console.WriteLine($"{(peopleForKilimandjaro * 1.0 / totalPeople) * 100:f2}%");
            Console.WriteLine($"{(peopleForK2 * 1.0 / totalPeople) * 100:f2}%");
            Console.WriteLine($"{(peopleForEverest * 1.0 / totalPeople) * 100:f2}%");

        }
    }
}
