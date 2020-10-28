using System;
using System.Linq;
using System.Text;

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
            while ((input = Console.ReadLine()) != "END")
            {
                switch (input)
                {
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        };
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(" ", elements));
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                }
            }
        }
    }
}
