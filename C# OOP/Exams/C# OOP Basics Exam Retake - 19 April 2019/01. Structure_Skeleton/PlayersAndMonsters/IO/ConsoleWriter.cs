
using System;
using System.IO;
using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            File.AppendAllText("../../../output.txt", message + Environment.NewLine);
            Console.WriteLine(message);
        }

        public void Write(string message)
        {
            Console.Write(message);
        }
    }
}
