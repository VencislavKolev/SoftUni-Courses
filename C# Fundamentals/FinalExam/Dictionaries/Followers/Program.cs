using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<int>> followers = new SortedDictionary<string, List<int>>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(": ");
                if (input[0] == "Log out")
                {
                    break;
                }
                string command = input[0];
                string username = input[1];
                if (command == "New follower")
                {
                    if (!IsExistingUser(followers, username))
                    {
                        AddNewUser(followers, username);
                    }
                }
                else if (command == "Like")
                {
                    int likeCount = int.Parse(input[2]);
                    if (!IsExistingUser(followers, username))
                    {
                        AddNewUser(followers, username);
                    }
                    followers[username][0] += likeCount;
                }
                else if (command == "Comment")
                {
                    if (!IsExistingUser(followers, username))
                    {
                        AddNewUser(followers, username);
                    }
                    followers[username][1] += 1;
                }
                else if (command == "Blocked")
                {
                    if (!IsExistingUser(followers, username))
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                    else
                    {
                        followers.Remove(username);
                    }
                }
            }
            Console.WriteLine($"{followers.Keys.Count} followers");
            foreach (var kvp in followers
                .OrderByDescending(x => x.Value[0]))
            {
                string user = kvp.Key;
                int sumLikesComments = kvp.Value[0] + kvp.Value[1];
                Console.WriteLine($"{user}: {sumLikesComments}");
            }
        }

        private static void AddNewUser(SortedDictionary<string, List<int>> followers, string username)
        {
            if (!followers.ContainsKey(username))
            {
                followers.Add(username, new List<int>());
                followers[username].Add(0); //likes
                followers[username].Add(0); //comments
            }
        }
        static bool IsExistingUser(SortedDictionary<string, List<int>> followers, string username)
        {
            if (followers.ContainsKey(username))
            {
                return true;
            }
            return false;
        }
    }
}
