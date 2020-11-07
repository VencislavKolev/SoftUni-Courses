
using System.Linq;
using System.Collections.Generic;
using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        ICollection<ICar> cars;
        public CarRepository()
        {
            this.cars = new List<ICar>();
        }

        public override void Add(ICar model)
        {
            this.cars.Add(model);
        }

        public override bool Remove(ICar model)
        {
            return this.cars.Remove(model);
        }
        public override ICar GetByName(string name)
        {
            return this.cars.FirstOrDefault(x => x.Model == name);
        }

    }
}
