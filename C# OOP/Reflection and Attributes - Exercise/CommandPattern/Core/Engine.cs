
using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpeter;
        public Engine(ICommandInterpreter commandInterpreterPassed)
        {
            this.commandInterpeter = commandInterpreterPassed;
        }
        public void Run()
        {
            while (true)
            {
                string inputArgs = Console.ReadLine();
                try
                {
                    string result = commandInterpeter.Read(inputArgs);
                    Console.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
