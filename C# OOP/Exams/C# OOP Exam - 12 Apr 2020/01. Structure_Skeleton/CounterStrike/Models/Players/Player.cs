
using System;
using System.Text;

using CounterStrike.Utilities.Messages;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private const int MIN_ARMOR = 0;
        private const int MIN_HEALTH = 0;

        private string username;
        private int health;
        private int armor;
        private IGun gun;
        public Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }
        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }
                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                //<=
                if (value < MIN_HEALTH)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }
                this.health = value;
            }
        }

        public int Armor
        {
            get => this.armor;
            private set
            {
                if (value < MIN_ARMOR)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }
                this.armor = value;
            }
        }

        public IGun Gun
        {
            get => this.gun;
            private set
            {
                this.gun = value ?? throw new ArgumentException(ExceptionMessages.InvalidGunName);
            }
        }

        public bool IsAlive => this.Health > MIN_HEALTH /*? true : false*/;

        public void TakeDamage(int points)
        {
            if (this.Armor > MIN_ARMOR)
            {
                if (this.Armor < points)
                {
                    points -= this.Armor;
                    this.Armor = 0;
                    this.Health -= points;
                }
                else
                {
                    this.Armor -= points;
                }
            }
            else if (this.Health > MIN_HEALTH)
            {
                if (this.Health < points)
                {
                    this.Health = 0;
                }
                else
                {
                    this.Health -= points;
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.Username}")
                .AppendLine($"--Health: {this.Health}")
                .AppendLine($"--Armor: {this.Armor}")
                .AppendLine($"--Gun: {this.Gun.Name}");

            return sb.ToString().TrimEnd();
        }
    }
}
