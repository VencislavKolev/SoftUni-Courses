using System;
using System.Linq;

namespace P01.ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] createCmd = Console.ReadLine().Split();
            string[] elements = createCmd.Skip(1).ToArray();
            ListyIterator<string> listyIterator = new ListyIterator<string>(elements);

            string input;
            bool result = true;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "Print")
                {
                    listyIterator.Print();
                    continue;
                }
                else if (input == "HasNext")
                {
                    result = listyIterator.HasNext();
                }
                else if (input == "Move")
                {
                    result = listyIterator.Move();
                }
                Console.WriteLine(result);
            }
        }
    }
}
