using System;

namespace _01._Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            double numOfStudents = int.Parse(Console.ReadLine());
            double lecturesCount = int.Parse(Console.ReadLine());
            double initialBonus = int.Parse(Console.ReadLine());

            double bestLectureAttendancesCount = 0;
            double maxBonusPoints = 0;
            for (int i = 0; i < numOfStudents; i++)
            {
                int studentAttendances = int.Parse(Console.ReadLine());
                double bonus = Math.Ceiling(studentAttendances / (lecturesCount) * (5 + initialBonus));

                if (bonus >= maxBonusPoints)
                {
                    maxBonusPoints = bonus;
                    bestLectureAttendancesCount = studentAttendances;
                }
            }
            Console.WriteLine($"Max Bonus: {maxBonusPoints}.");
            Console.WriteLine($"The student has attended {bestLectureAttendancesCount} lectures.");
        }
    }
}
