using System;

namespace _06._The_Most_Powerful_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string mostPowerfulWord = "";
            string currentWord = "";
            double maxAscii = 0;
            double asciiSum = 0;
            char x;
            while (input != "End of words")
            {
                currentWord = input;
                for (int i = 0; i < input.Length; i++)
                {
                    x = input[i];  //взима пореден символ от думата и изписва съответнана ASCII стойност
                    asciiSum += Convert.ToInt16(x); //превръщаме ASCII стойността в съответното число и прибавяме към сумата на предшните стойности
                }
                if (input[0] != 'a' && input[0] != 'e' && input[0] != 'i' && input[0] != 'o' && input[0] != 'u' && input[0] != 'y' &&
                  input[0] != 'A' && input[0] != 'E' && input[0] != 'I' && input[0] != 'O' && input[0] != 'U' && input[0] != 'Y')
                // ако първата буква НЕ е гласна
                {
                    asciiSum = Math.Floor(asciiSum / 3);
                }
                else
                {
                    asciiSum *= input.Length;
                }
                if (asciiSum >= maxAscii)
                {
                    maxAscii = asciiSum;
                    mostPowerfulWord = currentWord;
                }
                asciiSum = 0;
                input = Console.ReadLine();
            }
            Console.WriteLine($"The most powerful word is {mostPowerfulWord} - {maxAscii}");
        }
    }
}
