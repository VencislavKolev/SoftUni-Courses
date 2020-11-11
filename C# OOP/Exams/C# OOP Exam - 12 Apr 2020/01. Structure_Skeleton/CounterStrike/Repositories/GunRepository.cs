
using System;
using System.Linq;
using System.Collections.Generic;

using CounterStrike.Utilities.Messages;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private ICollection<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => (IReadOnlyCollection<IGun>)this.guns;

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }
            this.guns.Add(model);
        }
        public bool Remove(IGun model)
        {
            return this.guns.Remove(model);
        }

        public IGun FindByName(string name)
        {
            return this.guns.FirstOrDefault(x => x.Name == name);
        }

    }
}
