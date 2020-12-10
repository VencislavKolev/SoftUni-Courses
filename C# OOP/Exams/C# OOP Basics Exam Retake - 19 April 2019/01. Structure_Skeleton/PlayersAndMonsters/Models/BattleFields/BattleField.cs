
using System;
using System.Linq;

using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using System.Reflection.Metadata.Ecma335;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
            if (attackPlayer.GetType().Name == "Beginner")
            {
                this.IncreasePlayerHealth(attackPlayer);
                this.IncreasePlayerCardsDamagePoints(attackPlayer);
            }
            if (enemyPlayer.GetType().Name == "Beginner")
            {
                this.IncreasePlayerHealth(enemyPlayer);
                this.IncreasePlayerCardsDamagePoints(enemyPlayer);
            }

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);

            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);

            while (true)
            {
                int attackPlayerDamage = attackPlayer.CardRepository.Cards.Select(x => x.DamagePoints).Sum();

                enemyPlayer.TakeDamage(attackPlayerDamage);
                if (enemyPlayer.IsDead)
                {
                    break;
                }

                int enemyPlayerDamage = enemyPlayer.CardRepository.Cards.Select(x => x.DamagePoints).Sum();
                attackPlayer.TakeDamage(enemyPlayerDamage);
                if (attackPlayer.IsDead)
                {
                    break;
                }
            }

        }

        private void IncreasePlayerHealth(IPlayer player)
        {
            player.Health += 40;
        }

        private void IncreasePlayerCardsDamagePoints(IPlayer player)
        {
            foreach (var card in player.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }
    }
}
