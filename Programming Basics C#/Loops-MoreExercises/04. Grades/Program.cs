using System;

namespace _04._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numStudents = int.Parse(Console.ReadLine());
            double numFailed = 0;
            double totalScoreFailed = 0;
            double num3to399 = 0;
            double totalScore3to399 = 0;
            double num4to499 = 0;
            double totalScore4to499 = 0;
            double num5to6 = 0;
            double totalScore5to6 = 0;
            double averageScore = 0;

            for (int i = 1; i <= numStudents; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 3)
                {
                    totalScoreFailed += grade;
                    numFailed++;
                }
                else if (grade < 4)
                {
                    totalScore3to399 += grade;
                    num3to399++;
                }
                else if (grade < 5)
                {
                    totalScore4to499 += grade;
                    num4to499++;
                }
                else if (grade >= 5)
                {
                    totalScore5to6 += grade;
                    num5to6++;
                }
            }
            averageScore = (totalScoreFailed + totalScore3to399 + totalScore4to499 + totalScore5to6)
                / (numStudents);
            Console.WriteLine($"Top students: {(num5to6 / numStudents) * 100:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {(num4to499 / numStudents) * 100:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {(num3to399 / numStudents) * 100:f2}%");
            Console.WriteLine($"Fail: {(numFailed / numStudents) * 100:f2}%");
            Console.WriteLine($"Average: {averageScore:f2}");

        }
    }
}
