using System;
using System.Text;

namespace _02._Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] inputArgs = input.Split(':');
                string artist = inputArgs[0];
                string song = inputArgs[1];
                if (IsValidArtist(artist) && IsValidSong(song))
                {
                    int key = artist.Length;
                    StringBuilder encrypted = new StringBuilder();
                    for (int i = 0; i < input.Length; i++)
                    {
                        char charToEncrypt = input[i];
                        if (char.IsUpper(charToEncrypt) && charToEncrypt + key > 'Z')
                        {
                            charToEncrypt = (char)(charToEncrypt + key - 26);
                        }
                        else if (char.IsLower(charToEncrypt) && charToEncrypt + key > 'z')
                        {
                            charToEncrypt = (char)(charToEncrypt + key - 26);
                        }
                        else if (charToEncrypt == ':')
                        {
                            charToEncrypt = '@';
                        }
                        else if (charToEncrypt == ' ' || charToEncrypt == '\'')
                        {
                            encrypted.Append(charToEncrypt);
                            continue;
                        }
                        else
                        {
                            charToEncrypt = (char)(charToEncrypt + key);
                        }
                        encrypted.Append(charToEncrypt);
                    }
                    Console.WriteLine($"Successful encryption: {encrypted.ToString()}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }


                input = Console.ReadLine();
            }
        }
        public static bool IsValidSong(string song)
        {
            bool isValid = true;
            if (char.IsLower(song[0]))
            {
                isValid = false;
            }
            for (int i = 1; i < song.Length; i++)
            {
                char currChar = song[i];
                if (char.IsLower(currChar) &&
                    currChar != ' ')
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }
        public static bool IsValidArtist(string artist)
        {
            bool isValid = true;
            if (char.IsLower(artist[0]))
            {
                isValid = false;
            }
            for (int i = 1; i < artist.Length; i++)
            {
                char currChar = artist[i];
                if (char.IsUpper(currChar) &&
                    currChar != ' ' &&
                    currChar != '\'')
                {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }
    }
}
