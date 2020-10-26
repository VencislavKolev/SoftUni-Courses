using System;

namespace MyTuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] personBeer = Console.ReadLine()
                .Split();
            string[] numberInfo = Console.ReadLine()
                .Split();

            string personName = personInfo[0] + " " + personInfo[1];
            string personAddress = personInfo[2];

            string personNameBeer = personBeer[0];
            int litersBeer = int.Parse(personBeer[1]);

            int integerNum = int.Parse(numberInfo[0]);
            double doubleNum = double.Parse(numberInfo[1]);

            MyTuple<string, string> stringTuple = new MyTuple<string, string>(personName, personAddress);
            MyTuple<string, int> stringIntTuple = new MyTuple<string, int>(personNameBeer, litersBeer);
            MyTuple<int,double> intDoubleTuple = new MyTuple<int,double>(integerNum,doubleNum);

            Console.WriteLine(stringTuple);
            Console.WriteLine(stringIntTuple);
            Console.WriteLine(intDoubleTuple);
        }
    }
}
