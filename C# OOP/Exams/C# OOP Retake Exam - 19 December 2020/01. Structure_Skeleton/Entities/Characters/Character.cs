using System;

using WarCroft.Constants;
using WarCroft.Entities.Items;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.
        private string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;

            this.BaseHealth = health;
            this.Health = health;

            this.BaseArmor = armor;
            this.Armor = armor;

            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; }
        public double Health
        {
            get => this.health;

            set
            {
                if (value >= 0 && value <= this.BaseHealth)
                {
                    this.health = value;
                }
                else if (value < 0)
                {
                    this.health = 0;
                }
            }
        }
        public double BaseArmor { get; }
        public double Armor
        {
            get => this.armor;

            set
            {
                if (value >= 0)
                {
                    this.armor = value;
                }
            }
        }
        public Bag Bag { get; private set; }
        public double AbilityPoints { get; }
        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            if (this.Armor <= hitPoints)
            {
                hitPoints -= this.Armor;
                this.Armor = 0;
                if (hitPoints > 0)
                {
                    this.Health -= hitPoints;
                }
            }
            else
            {
                this.Armor -= hitPoints;
            }

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }
        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}