using System;

namespace _02._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            PrintGradeInWords(grade);
        }
        static void PrintGradeInWords(double grade)
        {
            //ако използваме Console.WriteLine във всяка проверка
            // string result е излишен
            string result = "";
            if (grade >= 2 && grade <= 2.99)
            {
                result = "Fail";
                //Console.WriteLine("Fail");
            }
            else if (grade >= 3 && grade <= 3.49)
            {
                result = "Poor";
            }
            else if (grade >= 3.50 && grade <= 4.49)
            {
                result = "Good";
            }
            else if (grade >= 4.5 && grade <= 5.49)
            {
                result = "Very good";
            }
            else if (grade >= 5.5 && grade <= 6.00)
            {
                result = "Excellent";
            }
            Console.WriteLine(result);
        }
    }
}
