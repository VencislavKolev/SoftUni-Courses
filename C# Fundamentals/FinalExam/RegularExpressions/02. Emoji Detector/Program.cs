using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string digitPattern = @"[0-9]";
            BigInteger coolThreshold = 1;
            MatchCollection matches = Regex.Matches(text, digitPattern);
            foreach (Match match in matches)
            {
                int currDigit = int.Parse(match.Value);
                coolThreshold *= currDigit;
            }
            string validEmojiPattern = @"([:]{2}|[*]{2})(?<name>[A-Z][a-z]{2,})\1";
            MatchCollection emojiMatches = Regex.Matches(text, validEmojiPattern);
            List<string> validEmojiList = new List<string>();
            foreach (Match emojiMatch in emojiMatches)
            {
                int asciiSum = 0;
                string emoji = emojiMatch.Groups["name"].Value;
                for (int i = 0; i < emoji.Length; i++)
                {
                    asciiSum += emoji[i];
                }
                if (asciiSum > coolThreshold)
                {
                    validEmojiList.Add(emojiMatch.Value);
                }
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");
            if (validEmojiList.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, validEmojiList));
            }
        }
    }
}
