using System;
using System.Linq;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
            {
                char currChar = text[i];
                int subSeqLength = 0;
                for (int j = i + 1; j < text.Length; j++)
                {
                    char nextChar = text[j];
                    if (currChar == nextChar)
                    {
                        subSeqLength++;
                    }
                    else
                    {
                        break;
                    }
                }
                text = text.Remove(i, subSeqLength);
            }
            Console.WriteLine(text);
            //char[] text = Console.ReadLine().ToCharArray();
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < text.Length - 1; i++)
            //{
            //    char left = text[i];
            //    char right = text[i + 1];
            //    if (left != right)
            //    {
            //        sb.Append(left);
            //    }
            //}
            //sb.Append(text.Last());
            //Console.WriteLine(sb);
        }
    }
}
