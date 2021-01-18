using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using WarCroft.Constants;
using WarCroft.Entities.Items;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characters;
        private List<Item> itemPool;
        public WarController()
        {
            this.characters = new List<Character>();
            this.itemPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterTypeAsString = args[0];
            string name = args[1];

            Character character;
            if (characterTypeAsString == "Warrior")
            {
                character = new Warrior(name);
            }
            else if (characterTypeAsString == "Priest")
            {
                character = new Priest(name);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterTypeAsString));
            }
            this.characters.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item;
            if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else if (itemName == "FirePotion")

            {
                item = new FirePotion();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }
            this.itemPool.Add(item);

            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string name = args[0];
            Character character = this.characters.FirstOrDefault(x => x.Name == name);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, name));
            }
            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item itemToPick = this.itemPool[this.itemPool.Count - 1]; //this.itemPool.Last(); option 2
            //MISTAKE -> Item was not removed after pick up
            this.itemPool.RemoveAt(this.itemPool.Count - 1);

            character.Bag.AddItem(itemToPick);

            return string.Format(SuccessMessages.PickUpItem, name, itemToPick.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string name = args[0];
            string itemName = args[1];
            Character character = this.characters.FirstOrDefault(x => x.Name == name);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, name));
            }
            Item item = character.Bag.GetItem(itemName);


            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, itemName));
            }

            character.UseItem(item);
            return string.Format(SuccessMessages.UsedItem, name, itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            var sortedCharacters = this.characters
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health);

            foreach (var character in sortedCharacters)
            {
                string characterStatus = character.IsAlive ? "Alive" : "Dead";

                sb.AppendLine(string.Format(SuccessMessages.CharacterStats,
                    character.Name,
                    character.Health,
                    character.BaseHealth,
                    character.Armor,
                    character.BaseArmor,
                    characterStatus));
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            // Warrior attacker = (Warrior)this.characters.FirstOrDefault(x => x.Name == attackerName);
            Character attacker = this.characters.FirstOrDefault(x => x.Name == attackerName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            Character receiver = this.characters.FirstOrDefault(x => x.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (attacker is Warrior warriorAttacker && warriorAttacker.IsAlive)
            {
                warriorAttacker.Attack(receiver);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter,
                attackerName,
                receiverName,
                attacker.AbilityPoints,
                receiverName,
                receiver.Health,
                receiver.BaseHealth,
                receiver.Armor,
                receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }
            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = this.characters.FirstOrDefault(x => x.Name == healerName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            Character receiver = this.characters.FirstOrDefault(x => x.Name == healingReceiverName);

            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            if (healer is Priest priestHealer && priestHealer.IsAlive)
            {
                priestHealer.Heal(receiver);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            return string.Format(SuccessMessages.HealCharacter,
                healerName,
                healingReceiverName,
                healer.AbilityPoints,
                receiver.Name,
                receiver.Health);
        }
    }
}
