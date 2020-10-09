using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int badGradesLimit = int.Parse(Console.ReadLine());
            string problemName = Console.ReadLine();
            int badGradesCounter = 0;
            int gradesSum = 0;
            int gradesCounter = 0;
            string lastProblemName = "";

            while (problemName!="Enough")
            {
                lastProblemName = problemName; ;
                int grade = int.Parse(Console.ReadLine());
                gradesSum += grade;
                gradesCounter++;

                if (grade<=4)
                {
                    badGradesCounter++;
                }

                if (badGradesCounter==badGradesLimit)
                {
                    break;
                }

                problemName = Console.ReadLine();
            }
            if (problemName=="Enough")
            {
                double averageScore = gradesSum*1.0 / gradesCounter;
                Console.WriteLine($"Average score: {averageScore:f2}");
                Console.WriteLine($"Number of problems: {gradesCounter}");
                Console.WriteLine($"Last problem: {lastProblemName}");
            }
            else
            {
                Console.WriteLine($"You need a break, {badGradesCounter} poor grades.");
            }
        }
    }
}
