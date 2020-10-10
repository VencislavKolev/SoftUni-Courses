using System;

namespace _05._Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());
            string decripted = null;
            for (int i = 0; i < lines; i++)
            {
                char character = char.Parse(Console.ReadLine());
                int newCharAscii = character + key;
                char newChar = Convert.ToChar(newCharAscii);
                decripted += newChar.ToString();
            }
            Console.WriteLine(decripted);
        }
    }
}
