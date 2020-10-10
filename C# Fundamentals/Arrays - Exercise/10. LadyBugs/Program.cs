using System;
using System.Linq;

namespace _10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {

            int fieldSize = int.Parse(Console.ReadLine());
            int[] initialIndexes = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            int[] field = new int[fieldSize];

            foreach (int index in initialIndexes)
            {
                if (index < 0 || index > fieldSize - 1)
                {
                    continue;
                }
                field[index] = 1;
            }
            string input = null;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] commands = input.Split();
                int ladyBugIndex = int.Parse(commands[0]);
                string direction = commands[1];
                int flyLenght = int.Parse(commands[2]);

                if (ladyBugIndex < 0 || ladyBugIndex > field.Length - 1 ||
                    field[ladyBugIndex] != 1)
                //дали индексът влиза в рамките на полето и 
                //дали на този индекс няма калинка
                //за да продължи ТРЯБВА да има калинка да дадения индекс!!!
                {
                    continue;
                }

                if (direction == "right")
                {
                    field[ladyBugIndex] = 0;
                    //калинката отлита и полето и присвоява стойност 0
                    int newIndex = ladyBugIndex + flyLenght;
                    while (newIndex < fieldSize)
                    {
                        //ако на новия индекс има калинка,търси друго поле
                        if (field[newIndex] == 1)
                        {
                            newIndex += flyLenght;
                            continue;
                        }
                        //като намери свободно поле си присвоява стойност 1
                        field[newIndex] = 1;
                        break;
                    }
                }
                else if (direction == "left")
                {
                    field[ladyBugIndex] = 0;
                    int newIndex = ladyBugIndex - flyLenght;
                    while (newIndex >= 0)
                    {
                        if (field[newIndex] == 1)
                        {
                            newIndex -= flyLenght;
                            continue;
                        }
                        field[newIndex] = 1;
                        break;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}
