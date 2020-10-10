using System;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int repeatTimes = int.Parse(Console.ReadLine());
            string repeated = RepeatText(text, repeatTimes);
            Console.WriteLine(repeated);

        }
        static string RepeatText(string text, int repeatTimes)
        {
            string output = "";
            for (int i = 0; i < repeatTimes; i++)
            {
                output += text;
            }
            return output;
        }
    }
}
