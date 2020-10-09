using System;

namespace _04._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int juryMarks = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();
            double grade = 0;
            double gradeSum = 0;
            int presentationCounter = 0;
            double averageGrade = 0;
            double averageGradeSum = 0;
            while (presentationName != "Finish")
            {
                presentationCounter++;
                for (int i = 1; i <= juryMarks; i++)
                {
                    grade = double.Parse(Console.ReadLine());
                    gradeSum += grade;
                }
                averageGrade = gradeSum / juryMarks;
                averageGradeSum += averageGrade;
                Console.WriteLine($"{presentationName} - {averageGrade:f2}.");
                averageGrade = 0;
                gradeSum = 0;
                presentationName = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {averageGradeSum / presentationCounter:f2}.");
        }
    }
}
