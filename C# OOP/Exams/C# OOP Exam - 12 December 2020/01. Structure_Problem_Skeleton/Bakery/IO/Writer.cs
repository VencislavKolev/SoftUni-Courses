﻿namespace Bakery.IO
{
    using System;
    using System.IO;
    using Bakery.IO.Contracts;

    public class Writer : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
           // File.AppendAllText("../../../output.txt", message + Environment.NewLine);
            Console.WriteLine(message);
        }
    }
}
