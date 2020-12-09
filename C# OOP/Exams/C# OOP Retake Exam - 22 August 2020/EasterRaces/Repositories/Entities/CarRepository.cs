using System.Linq;
using System.Collections.Generic;

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private ICollection<ICar> drivers;
        public CarRepository()
        {
            this.drivers = new List<ICar>();
        }
        public void Add(ICar model)
            => this.drivers.Add(model);

        public IReadOnlyCollection<ICar> GetAll()
            => (IReadOnlyCollection<ICar>)this.drivers;

        public ICar GetByName(string name)
            => this.drivers.FirstOrDefault(x => x.Model == name);

        public bool Remove(ICar model)
            => this.drivers.Remove(model);
    }
}
