using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] morseText = Console.ReadLine().Split();
            Dictionary<string, char> dict = new Dictionary<string, char>()
            {
                { ".-"  ,'a'},      {  "-...",'b'},      { "-.-.",'c'},
                { "-.." ,'d'},      { "."   ,'e' },      {"..-.",'f' },
                { "--." ,'g'},      {  "....",'h'},      { "..",'i'  },
                { ".---",'j'},      {  "-.-" ,'k'},      { ".-..",'l'},
                { "--"  ,'m'},      { "-."  ,'n' },      { "---",'o' },
                { ".--.",'p'},      { "--.-", 'q'},      { ".-.",'r' },
                { "..." ,'s'},      { "-"   ,'t' },      { "..-",'u' },
                { "...-",'v'},      { ".--" , 'w'},      { "-..-",'x'},
                { "-.--",'y'},      {  "--..",'z'},      {"|",' '}
            };
            StringBuilder translated = new StringBuilder();
            for (int i = 0; i < morseText.Length; i++)
            {
                string symbol = morseText[i];
                if (dict.ContainsKey(symbol))
                {
                    char englishChar = dict[symbol];
                    translated.Append(englishChar);
                }
            }
            Console.WriteLine(translated.ToString().ToUpper());
        }
    }
}
