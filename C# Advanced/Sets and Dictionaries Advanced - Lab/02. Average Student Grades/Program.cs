using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> myStudents = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < studentsCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);
                if (!myStudents.ContainsKey(name))
                {
                    myStudents.Add(name, new List<decimal>());
                }
                myStudents[name].Add(grade);

            }
            foreach (var (studentName, studentGrades) in myStudents)
            {
                string grades = string.Join(" ", studentGrades
                    .Select(x => x.ToString("f2")));
                decimal averageGrade = studentGrades.Average();
                Console.WriteLine($"{studentName} -> {grades} " +
                    $"(avg: {averageGrade:f2})");
            }
        }
    }
}
