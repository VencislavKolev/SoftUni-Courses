using P02.VehiclesExtension.Core;
using P02.VehiclesExtension.Core.Contracts;
using System;

namespace P02.VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
