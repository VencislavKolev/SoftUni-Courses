
using System.Linq;
using System.Collections.Generic;
using EasterRaces.Models.Races.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : Repository<IRace>
    {
        private ICollection<IRace> races;
        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public override void Add(IRace model)
        {
            this.races.Add(model);
        }
        public override bool Remove(IRace model)
        {
            return this.races.Remove(model);
        }

        public override IRace GetByName(string name)
        {
            return this.races.FirstOrDefault(x => x.Name == name);
        }

    }
}
