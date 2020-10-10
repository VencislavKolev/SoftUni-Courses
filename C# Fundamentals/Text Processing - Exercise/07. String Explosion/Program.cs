using System;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main()
        {
            string field = Console.ReadLine();
            int power = 0;
            for (int i = 0; i < field.Length; i++)
            {
                if (power > 0 && field[i] != '>')
                {
                    field = field.Remove(i, 1);
                    power--;
                    i--;
                }
                else if (field[i] == '>')
                {
                    power += int.Parse(field[i + 1].ToString());
                }
            }
            Console.WriteLine(field);
        }
    }
}