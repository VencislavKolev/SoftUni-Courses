using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsWithPasswords = new Dictionary<string, string>();
            ProcessFirstInput(contestsWithPasswords);

            SortedDictionary<string, Dictionary<string, int>> rankingDict = new SortedDictionary<string, Dictionary<string, int>>();

            ProcessSecondInput(contestsWithPasswords, rankingDict);

            PrintBestCandidate(rankingDict);
            Console.WriteLine("Ranking:");
            PrintFinalRanking(rankingDict);

            //Other way to find the BEST CANDIDATE
            //string bestUser = string.Empty;
            //int maxPoints = int.MinValue;
            //foreach (var student in rankingDict)
            //{
            //    string currName = student.Key;
            //    int currPoints = 0;
            //    foreach (var cpp in student.Value)
            //    {
            //        currPoints += cpp.Value;
            //    }
            //    if (currPoints > maxPoints)
            //    {
            //        maxPoints = currPoints;
            //        bestUser = currName;
            //    }
            //}
            //Console.WriteLine($"Best candidate is {bestUser} with total {maxPoints} points.");
        }

        private static void ProcessSecondInput(Dictionary<string, string> contestsWithPasswords, SortedDictionary<string, Dictionary<string, int>> rankingDict)
        {
            string secondInput;
            while ((secondInput = Console.ReadLine()) != "end of submissions")
            {
                string[] secInputArgs = secondInput.Split("=>");
                string contest = secInputArgs[0];
                string password = secInputArgs[1];
                string userName = secInputArgs[2];
                int points = int.Parse(secInputArgs[3]);

                if (contestsWithPasswords.ContainsKey(contest) && contestsWithPasswords[contest] == password)
                {
                    ProcessValidContestPoints(rankingDict, contest, userName, points);
                }
            }
        }

        private static void ProcessValidContestPoints(SortedDictionary<string, Dictionary<string, int>> rankingDict, string contest, string userName, int points)
        {
            if (!rankingDict.ContainsKey(userName))
            {
                rankingDict.Add(userName, new Dictionary<string, int>());
            }
            if (!rankingDict[userName].ContainsKey(contest))
            {
                rankingDict[userName][contest] = points;
            }
            int currBestPoints = rankingDict[userName][contest];
            if (points > currBestPoints)
            {
                rankingDict[userName][contest] = points;
            }
        }

        private static void ProcessFirstInput(Dictionary<string, string> contestPassword)
        {
            string firstInput;
            while ((firstInput = Console.ReadLine()) != "end of contests")
            {
                string[] firstInputArgs = firstInput.Split(':');
                string contest = firstInputArgs[0];
                string password = firstInputArgs[1];
                contestPassword.Add(contest, password);
            }
        }

        private static void PrintFinalRanking(SortedDictionary<string, Dictionary<string, int>> rankingDict)
        {
            foreach (var student in rankingDict)
            {
                Console.WriteLine(student.Key);
                foreach (var cpp in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#{new string(' ', 2)}{cpp.Key} -> {cpp.Value}");
                }
            }
        }

        private static void PrintBestCandidate(SortedDictionary<string, Dictionary<string, int>> rankingDict)
        {
            KeyValuePair<string, Dictionary<string, int>> bestCandidate = rankingDict.
                            OrderByDescending(kvp => kvp.Value.Values.Sum())
                            .First();
            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");
        }
    }
}
