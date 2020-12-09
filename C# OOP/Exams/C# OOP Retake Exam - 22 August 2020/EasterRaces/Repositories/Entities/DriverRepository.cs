using System.Linq;
using System.Collections.Generic;

using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private ICollection<IDriver> drivers;
        public DriverRepository()
        {
            this.drivers = new List<IDriver>();
        }
        public void Add(IDriver model)
            => this.drivers.Add(model);

        public IReadOnlyCollection<IDriver> GetAll()
            => (IReadOnlyCollection<IDriver>)this.drivers;

        public IDriver GetByName(string name)
            => this.drivers.FirstOrDefault(x => x.Name == name);

        public bool Remove(IDriver model)
            => this.drivers.Remove(model);
    }
}
