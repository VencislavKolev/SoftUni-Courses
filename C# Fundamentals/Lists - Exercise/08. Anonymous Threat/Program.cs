using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine().Split().ToList();
            string input = Console.ReadLine();


            while (input != "3:1")
            {
                string[] commands = input.Split();
                string action = commands[0];
                if (action == "merge")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    string mergedWord = string.Empty;

                    if (startIndex < 0 || startIndex > data.Count - 1)
                    {
                        startIndex = 0;
                    }
                    if (endIndex > data.Count - 1)
                    {
                        endIndex = data.Count - 1;
                    }
                    if ((startIndex >= 0 && startIndex < endIndex) &&
                        (endIndex > startIndex && endIndex <= data.Count - 1))
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            mergedWord += data[i];
                        }
                        data.RemoveRange(startIndex, endIndex - startIndex + 1);
                        data.Insert(startIndex, mergedWord);
                    }
                }
                else if (action == "divide")
                {
                    int index = int.Parse(commands[1]);
                    int partitions = int.Parse(commands[2]);

                    //abcdef        abcd
                    //3             3
                    //ab cd ef      a b cd

                    string currElement = data[index];
                    int lenghtOfSubString = currElement.Length / partitions;
                    List<string> dividedData = new List<string>();
                    int startIndex = 0;
                    for (int i = 0; i < partitions; i++)
                    {
                        //ако е на последната операция се добавят останалите символи
                        if (i == partitions - 1)
                        {
                            dividedData.Add(currElement.Substring(startIndex, currElement.Length - startIndex));
                            break;
                        }
                        else
                        {
                            dividedData.Add(currElement.Substring(startIndex, lenghtOfSubString));
                            startIndex += lenghtOfSubString;
                        }
                    }
                    data.Remove(currElement);
                    data.InsertRange(index, dividedData);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", data));
        }
    }
}
