using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string artistPattern = @"^(?<artist>[A-Z]{1}[a-z\' ]+)$";
            string songPattern = @"^(?<song>[A-Z ]+)$";
            while (true)
            {
                string[] input = Console.ReadLine().Split(':');
                if (input[0] == "end")
                {
                    break;
                }
                string artist = input[0];
                string song = input[1];
                Match artistMatch = Regex.Match(artist, artistPattern);
                Match songMatch = Regex.Match(song, songPattern);
                if (songMatch.Success && artistMatch.Success)
                {
                    int key = artist.Length;
                    StringBuilder encryptedArtist = new StringBuilder();
                    StringBuilder encryptedSong = new StringBuilder();

                    for (int i = 0; i < artist.Length; i++)
                    {
                        int encryptedLetter;

                        if (char.IsUpper(artist[i]) && artist[i] + key > 90)
                        {
                            encryptedLetter = artist[i] + key - 26;
                        }
                        else if (char.IsLower(artist[i]) && artist[i] + key > 122)
                        {
                            encryptedLetter = artist[i] + key - 26;
                        }
                        else if (artist[i] == ' ')
                        {
                            encryptedLetter = artist[i];
                        }
                        else if (artist[i] == '\'')
                        {
                            encryptedLetter = artist[i];
                        }
                        else
                        {
                            encryptedLetter = artist[i] + key;
                        }
                        encryptedArtist.Append((char)encryptedLetter);
                    }
                    for (int i = 0; i < song.Length; i++)
                    {
                        int encryptedLetter;

                        if (char.IsUpper(song[i]) && song[i] + key > 90)
                        {
                            encryptedLetter = song[i] + key - 26;
                        }
                        else if (char.IsLower(song[i]) && song[i] + key > 122)
                        {
                            encryptedLetter = song[i] + key - 26;
                        }
                        else if (song[i] == ' ')
                        {
                            encryptedLetter = (' ');
                        }
                        else if (song[i] == '\'')
                        {
                            encryptedLetter = ('\'');
                        }
                        else
                        {
                            encryptedLetter = song[i] + key;
                        }
                        encryptedSong.Append((char)encryptedLetter);
                    }
                    Console.WriteLine($"Successful encryption: {encryptedArtist}@{encryptedSong}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
