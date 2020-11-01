using P05.FootballTeamGenerator.Common;
using P05.FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace P05.FootballTeamGenerator.Core
{
    public class Engine
    {
        private List<Team> teams;
        public Engine()
        {
            this.teams = new List<Team>();
        }
        public void Run()
        {
            string[] inputArgs = Console.ReadLine()
                .Split(';', StringSplitOptions.None);

            while (inputArgs[0] != "END")
            {
                try
                {
                    string command = inputArgs[0];
                    string teamName = inputArgs[1];
                    if (command == "Team")
                    {
                        AddTeam(teamName);
                    }
                    else if (command == "Add")
                    {
                        AddPlayer(inputArgs, teamName);
                    }
                    else if (command == "Remove")
                    {
                        RemovePlayer(inputArgs, teamName);
                    }
                    else if (command == "Rating")
                    {
                        GetTeamRating(teamName);
                    }
                }

                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                inputArgs = Console.ReadLine().Split(';', StringSplitOptions.None);
            }
        }

        private void GetTeamRating(string teamName)
        {
            this.ValidateTeamExists(teamName);
            Team team = this.teams.First(t => t.Name == teamName);
            Console.WriteLine(team);
        }

        private void RemovePlayer(string[] inputArgs, string teamName)
        {
            string playerName = inputArgs[2];
            this.ValidateTeamExists(teamName);
            Team team = this.teams.First(t => t.Name == teamName);
            team.RemovePlayer(playerName);
        }

        private void AddPlayer(string[] inputArgs, string teamName)
        {
            string playerName = inputArgs[2];
            this.ValidateTeamExists(teamName);
            Team teamToAddPlayer = this.teams.First(t => t.Name == teamName);

            string[] playerStats = inputArgs.Skip(3).ToArray();
            Stats stats = this.CreateStats(playerStats);
            Player player = new Player(playerName, stats);

            teamToAddPlayer.AddPlayer(player);
        }

        private void ValidateTeamExists(string teamName)
        {
            if (!this.teams.Any(t => t.Name == teamName))
            {
                throw new InvalidOperationException(string.Format(ExceptonMessages.NonExistingTeamMessage, teamName));
            }
        }

        private void AddTeam(string teamName)
        {
            Team team = new Team(teamName);
            this.teams.Add(team);
        }
        private Stats CreateStats(string[] playerStats)
        {
            int endurance = int.Parse(playerStats[0]);
            int sprint = int.Parse(playerStats[1]);
            int dribble = int.Parse(playerStats[2]);
            int passing = int.Parse(playerStats[3]);
            int shooting = int.Parse(playerStats[4]);
            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
            return stats;
        }
    }

}
