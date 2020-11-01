using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var randList = new RandomList();
            randList.Add("Pesho");
            randList.Add("Gosho");
            randList.Add("Sasho");

            var res = randList.RandomString();
            var res2 = randList.RandomString();
            Console.WriteLine(res);
            Console.WriteLine(res2);
        }
    }
}
