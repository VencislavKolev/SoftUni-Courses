using System;
using System.Linq;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] personDrunkStatus = Console.ReadLine()
                .Split();
            string[] bankInfo = Console.ReadLine()
                .Split();

            string fullName = personInfo[0] + " " + personInfo[1];
            string address = personInfo[2];
            string town = string.Join(" ", personInfo.Skip(3));

            string nameOfDrinker = personDrunkStatus[0];
            int litersBeer = int.Parse(personDrunkStatus[1]);
            bool isDrunk = personDrunkStatus[2] == "drunk" ? true : false;

            string nameOfBankCustomer = bankInfo[0];
            double bankBalance = double.Parse(bankInfo[1]);
            string bankName = bankInfo[2];

            MyThreeuple<string, string, string> personThreeuple = new MyThreeuple<string, string, string>(fullName, address, town);
            MyThreeuple<string, int, bool> drunkThreeuple = new MyThreeuple<string, int, bool>(nameOfDrinker, litersBeer, isDrunk);
            MyThreeuple<string, double, string> bankThreeuple = new MyThreeuple<string, double, string>(nameOfBankCustomer, bankBalance, bankName);

            Console.WriteLine(personThreeuple);
            Console.WriteLine(drunkThreeuple);
            Console.WriteLine(bankThreeuple);
        }
    }
}
