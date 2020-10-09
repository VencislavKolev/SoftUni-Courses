using System;


    class Program
    {
        static void Main()
        {
        Console.Write("Моля въведи едно число: ");
        string str = Console.ReadLine();
        int num = int.Parse(str);
        
        Console.WriteLine("Числото е: " + num);
        int numplusone = num + 1;
        Console.WriteLine("Числото +1 =" + numplusone);
        }
    }
