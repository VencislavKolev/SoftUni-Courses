using _2.Facade.Models;
using System;

namespace _2.Facade
{
    public class Program
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
            .Info
                .WithType("BMW")
                .WithColor("Black")
                .WithNumberOfDoors(5)
            .Built
                .InCity("Leipzig")
                .AtAddress("BMW Factory")
            .Build();

            Console.WriteLine(car);
        }
    }
}
