
using System;

using CounterStrike.Utilities.Messages;
using CounterStrike.Models.Guns.Contracts;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private const int MIN_BULLET_COUNT = 0;
        private string name;
        private int bullets;

        public Gun(string name, int bullets)
        {
            this.Name = name;
            this.BulletsCount = bullets;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }
                this.name = value;
            }
        }

        public int BulletsCount
        {
            get => this.bullets;
            protected set
            {
                if (value < MIN_BULLET_COUNT)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
                }
                this.bullets = value;
            }
        }

        public abstract int Fire();
    }
}
