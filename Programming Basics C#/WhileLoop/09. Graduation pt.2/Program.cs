using System;

namespace _09._Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int level = 1;
            double sumGrades = 0;
            double averageGrade = 0;
            int failCounter = 0;
            while (level <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4)
                {
                    level++;
                    sumGrades += grade;
                }
                else
                {
                    failCounter++;
                    if (failCounter > 1)
                    {
                        Console.WriteLine($"{name} has been excluded at {level} grade");
                       //break 
                        return;
                    }
                    continue;
                }
            }
            //if (failCounter<=1)
            //{
                averageGrade = sumGrades / 12;
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
            //}
        }
    }
}
