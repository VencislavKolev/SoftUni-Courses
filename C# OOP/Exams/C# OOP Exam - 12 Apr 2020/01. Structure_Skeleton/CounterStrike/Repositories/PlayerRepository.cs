
using System;
using System.Linq;
using System.Collections.Generic;

using CounterStrike.Utilities.Messages;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private ICollection<IPlayer> players;
        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => (IReadOnlyCollection<IPlayer>)this.players;

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }
            this.players.Add(model);
        }
        public bool Remove(IPlayer model)
        {
            return this.players.Remove(model);
        }

        public IPlayer FindByName(string name)
        {
            return this.players.FirstOrDefault(x => x.Username == name);
        }

    }
}
