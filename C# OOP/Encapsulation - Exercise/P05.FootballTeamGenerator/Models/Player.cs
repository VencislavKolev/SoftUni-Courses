

using P05.FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;

namespace P05.FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;
        public Player(string name,Stats stat)
        {
            this.Name = name;
            this.Stats = stat;
        }
        public Stats Stats { get; }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptonMessages.InvalidNameMessage);
                }
                this.name = value;
            }
        }
        public double OverallSkill => this.Stats.AverageStat;
    }
}
