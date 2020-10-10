using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());
            int coursesSoftUni = (int)Math.Ceiling
                ((double)numberOfPeople / elevatorCapacity);
            Console.WriteLine(coursesSoftUni);
            //int courses = 0;
            //while (numberOfPeople != 0)
            //{
            //    if (numberOfPeople <= elevatorCapacity)
            //    {
            //        courses += 1;
            //        break;
            //    }
            //    else if (numberOfPeople > elevatorCapacity)
            //    {
            //        courses = numberOfPeople / elevatorCapacity;
            //        numberOfPeople -= elevatorCapacity * courses;
            //    }
            //}
            //Console.WriteLine(courses);

        }
    }
}
