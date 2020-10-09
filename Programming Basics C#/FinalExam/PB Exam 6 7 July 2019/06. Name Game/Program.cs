using System;

namespace _06._Name_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int number = 0;
            int currentPlayerPoints = 0;
            string currPlayerName = "";
            char x;
            int asciiValue = 0;
            int maxPoints = 0;
            string firstPlacePlayer = "";

            while (input != "Stop")
            {
                currPlayerName = input;
                for (int i = 0; i < currPlayerName.Length; i++)
                {
                    number = int.Parse(Console.ReadLine());
                    x = currPlayerName[i];
                    asciiValue = Convert.ToInt16(x);
                    if (asciiValue == number)
                    {
                        currentPlayerPoints += 10;
                    }
                    else
                    {
                        currentPlayerPoints += 2;
                    }
                }
                if (currentPlayerPoints>=maxPoints)
                {
                    maxPoints = currentPlayerPoints;
                    firstPlacePlayer = currPlayerName;
                }
                currentPlayerPoints = 0;
                input = Console.ReadLine();
            }
            Console.WriteLine($"The winner is {firstPlacePlayer} with {maxPoints} points!");
        }
    }
}
