
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => (IReadOnlyCollection<IComponent>)this.components;
        public IReadOnlyCollection<IPeripheral> Peripherals => (IReadOnlyCollection<IPeripheral>)this.peripherals;

        public override decimal Price =>
            base.Price +
            this.Components.Sum(x => x.Price) +
            this.Peripherals.Sum(x => x.Price);

        public override double OverallPerformance => this.Components.Count > 0 ?
            base.OverallPerformance +
            this.Components.Average(x => x.OverallPerformance)
            : base.OverallPerformance;

        public void AddComponent(IComponent component)
        {
            if (this.Components.Contains(component))
            {
                string componentType = component.GetType().Name;
                string computerType = this.GetType().Name;

                string excMsg = string.Format(ExceptionMessages.ExistingComponent, componentType, computerType, component.Id);

                throw new ArgumentException(excMsg);
            }
            this.components.Add(component);
        }


        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Contains(peripheral))
            {
                string peripheralType = peripheral.GetType().Name;
                string computerType = this.GetType().Name;

                string excMsg = string.Format(ExceptionMessages.ExistingPeripheral, peripheralType, computerType, peripheral.Id);

                throw new ArgumentException(excMsg);
            }
            this.peripherals.Add(peripheral);
        }
        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = this.Components
                 .FirstOrDefault(x => x.GetType().Name == componentType);

            if (component != null)
            {
                this.components.Remove(component);
            }
            return component;
        }
        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = this.Peripherals
                .FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (peripheral != null)
            {
                this.peripherals.Remove(peripheral);
            }
            return peripheral;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            sb.AppendLine($" Components ({this.Components.Count}):");
            foreach (var component in this.Components)
            {
                sb.AppendLine("  " + component.ToString());
            }

            double averageOverallPeripheralPerformance = 0.0;
            if (this.Peripherals.Any())
            {
                averageOverallPeripheralPerformance = this.Peripherals.Average(x => x.OverallPerformance);
            }

            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({averageOverallPeripheralPerformance:f2}):");
            foreach (var peripheral in this.Peripherals)
            {
                sb.AppendLine("  " + peripheral.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
