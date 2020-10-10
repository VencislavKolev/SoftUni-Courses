using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace _3._Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            string capitalLetterPattern = @"(?<sign>[#$%\*&])(?<capLet>[A-Z]+)(\k<sign>)";
            string asciiValAndLenghtPattern = @"(?<asciiValue>[6-9][0-9]):(?<length>[0-9]{2})";
            //@"(?<asciiValue>[65-90]+):(?<length>[0-9]{2})";
            Dictionary<char, int> data = new Dictionary<char, int>();
            //  List<char> capitalLetters = new List<char>();
            string[] input = Console.ReadLine().Split('|');
            for (int i = 1; i <= input.Length - 1; i++)
            {
                if (i == 1)
                {
                    Match match = Regex.Match(input[0], capitalLetterPattern);
                    if (match.Success)
                    {
                        for (int j = 0; j < match.Groups["capLet"].Value.Length; j++)
                        {
                            char currChar = match.Groups["capLet"].Value[j];
                            if (!data.ContainsKey(currChar))
                            {
                                data[currChar] = 0;
                            }
                            // capitalLetters.Add(match.Groups["capLet"].Value[j]);
                        }
                    }
                }

                else if (i == 2)
                {
                    MatchCollection matches = Regex.Matches(input[1], asciiValAndLenghtPattern);
                    foreach (Match match in matches)
                    {
                        if (match.Success)
                        {
                            int asciiValue = int.Parse(match.Groups["asciiValue"].Value);
                            int length = int.Parse(match.Groups["length"].Value);
                            foreach (var kvp in data)
                            {
                                char thisChar = kvp.Key;
                                if (thisChar == asciiValue)
                                {
                                    data[thisChar] = length;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            string[] words = input[2].Split();
            foreach (var kvp in data)
            {
                char startChar = kvp.Key;
                int wordLength = kvp.Value + 1;
                foreach (var word in words)
                {
                    if (word.Length == wordLength
                        && word.StartsWith(startChar))
                    {
                        Console.WriteLine(word);
                    }
                }
            }
        }
    }
}
//using System;
//using System.Text.RegularExpressions;

//namespace PostOffice
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string[] input = Console.ReadLine().Split("|");

//            string firstPart = input[0];
//            string secondPart = input[1];
//            string thirdPart = input[2];

//            string firstPattern = @"([#$%*&])(?<capitals>[A-Z]+)(\1)";
//            Match firstMatch = Regex.Match(firstPart, firstPattern);
//            string capitals = firstMatch.Groups["capitals"].Value;

//            for (int index = 0; index < capitals.Length; index++)
//            {
//                char startLetter = capitals[index];
//                int ASCIIcode = startLetter;

//                string secondPattern = $@"{ASCIIcode}:(?<length>[0-9][0-9])";
//                Match secondMatch = Regex.Match(secondPart, secondPattern);
//                int length = int.Parse(secondMatch.Groups["length"].Value);

//                string thirdPattern = $@"(?<=\s|^){startLetter}[^\s]{{{length}}}(?=\s|$)";
//                Match thirdMatch = Regex.Match(thirdPart, thirdPattern);
//                string word = thirdMatch.ToString();

//                Console.WriteLine(word);
//            }
//        }
//    }
//}