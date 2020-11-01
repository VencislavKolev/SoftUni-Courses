using P05.FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace P05.FootballTeamGenerator.Models
{
    public class Stats
    {
        private const int MIN_STAT_VALUE = 0;
        private const int MAX_STAT_VALUE = 100;
        private const double STATS_COUNT = 5.0;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                ValidateStat(value, nameof(this.Endurance));
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                ValidateStat(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                ValidateStat(value, nameof(this.Sprint));
                this.dribble = value;
            }
        }
        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                ValidateStat(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }
        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                ValidateStat(value, nameof(this.Passing));
                this.passing = value;
            }
        }
        public double AverageStat => (this.Endurance + this.Sprint + this.Dribble + this.Shooting + this.Passing) / STATS_COUNT;

        private void ValidateStat(int value, string statName)
        {
            if (value < MIN_STAT_VALUE || value > MAX_STAT_VALUE)
            {
                string exMsg = string.Format(ExceptonMessages.InvalidStatRangeMessage, statName, MIN_STAT_VALUE, MAX_STAT_VALUE);
                throw new ArgumentException(exMsg);
            }
        }
    }
}
