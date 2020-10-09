using System;

namespace _08._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int level = 1;
            double sumGrades = 0;
            double averageGrade = 0;
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
                    continue;
                }
            }
            averageGrade = sumGrades / 12;
            Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
        }
    }
}
