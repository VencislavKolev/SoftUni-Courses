using System;
using System.IO;
using System.IO.Compression;

namespace _6._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string filesPath = @"C:\Users\Asus\Downloads\04. CSharp-Advanced-Streams-Files-and-Directories-Exercise-Resources";
            string extractPath = @"C:\Users\Asus\source\repos\C# Advanced\Streams, Files and Directories - Exercise\6. Zip and Extract\myArchieve.zip";
            string extractToFolder = @"C:\Users\Asus\source\repos\C# Advanced\Streams, Files and Directories - Exercise\6. Zip and Extract\Extracted";
            
            ZipFile.CreateFromDirectory(filesPath, extractPath);
            ZipFile.ExtractToDirectory(extractPath, extractToFolder);

            
        }
    }
}
