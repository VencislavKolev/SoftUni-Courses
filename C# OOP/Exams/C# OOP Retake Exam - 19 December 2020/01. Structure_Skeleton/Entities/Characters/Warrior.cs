using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double initBaseHealth = 100;
        private const double initBaseArmor = 50;
        private const double initAbilityPoints = 40;

        public Warrior(string name)
            : base(name, initBaseHealth, initBaseArmor, initAbilityPoints,new Satchel())
        {

        }
        public void Attack(Character character)
        {
            this.EnsureAlive();

            //if (!character.IsAlive)
            //{
            //    throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            //}

            if (this.Equals(character))
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            character.TakeDamage(this.AbilityPoints);
            //TakeDamage() checks if character isAlive
        }
    }
}
