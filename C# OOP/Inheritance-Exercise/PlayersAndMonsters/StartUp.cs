using System;
namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var bladeKnight = new BladeKnight("Gosho", 5);
            Console.WriteLine(bladeKnight);
        }
    }
}