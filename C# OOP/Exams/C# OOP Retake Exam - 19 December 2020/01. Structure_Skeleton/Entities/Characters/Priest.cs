
using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double priestInitBaseHealth = 50;
        private const double priestInitBaseArmor = 25;
        private const double priestInitAbilityPoints = 40;
        public Priest(string name)
            : base(name, priestInitBaseHealth, priestInitBaseArmor, priestInitAbilityPoints, new Backpack())
        {
        }


        public void Heal(Character character)
        {
            this.EnsureAlive();

            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
            character.Health += this.AbilityPoints;

        }
    }
}
