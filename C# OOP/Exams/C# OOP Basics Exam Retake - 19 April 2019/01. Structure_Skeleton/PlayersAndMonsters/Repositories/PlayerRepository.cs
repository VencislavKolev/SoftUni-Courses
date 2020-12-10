
using System;
using System.Linq;
using System.Collections.Generic;

using PlayersAndMonsters.Repositories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ICollection<IPlayer> players = new List<IPlayer>();

        public int Count => this.Players.Count;

        public IReadOnlyCollection<IPlayer> Players => (IReadOnlyCollection<IPlayer>)this.players;

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            if (this.Players.Any(x => x.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            return this.Players.FirstOrDefault(x => x.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            return this.players.Remove(player);
        }
    }
}
