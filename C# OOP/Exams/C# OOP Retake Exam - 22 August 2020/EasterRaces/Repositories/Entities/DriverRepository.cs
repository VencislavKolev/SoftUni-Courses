using System.Linq;
using System.Collections.Generic;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        ICollection<IDriver> drivers;
        public DriverRepository()
        {
            this.drivers = new List<IDriver>();
        }

        public override void Add(IDriver model)
        {
            this.drivers.Add(model);
        }
        public override bool Remove(IDriver model)
        {
           return this.drivers.Remove(model);
        }
        public override IDriver GetByName(string name)
        {
            return this.drivers.FirstOrDefault(x => x.Name == name);
        }
    }
}
