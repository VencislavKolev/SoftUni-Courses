
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

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
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

        public override double OverallPerformance
            => CalculateOverallPerformance();

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(x => x.GetType() == component.GetType()))
            {
                string excMsg = string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id);

                throw new ArgumentException(excMsg);
            }
            this.components.Add(component);
        }


        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(x => x.GetType() == peripheral.GetType()))
            {
                string excMsg = string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id);

                throw new ArgumentException(excMsg);
            }
            this.peripherals.Add(peripheral);
        }
        public IComponent RemoveComponent(string componentType)
        {
            if (!this.components.Any(x => x.GetType().Name == componentType))
            {
                string excMsg = string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id);
                throw new ArgumentException(excMsg);
            }

            IComponent component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            this.components.Remove(component);

            return component;
        }
        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!this.peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                string excMsg = string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id);
                throw new ArgumentException(excMsg);
            }

            IPeripheral peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheral);

            return peripheral;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            sb.AppendLine($" Components ({this.Components.Count}):");
            foreach (var component in this.Components)
            {
                sb.AppendLine($"  {component}");
            }

            string averageResult = this.Peripherals.Count == 0 ? "0.00" :
                this.Peripherals.Average(x => x.OverallPerformance).ToString("F2");

            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({averageResult}):");
            foreach (var peripheral in this.Peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }

        private double CalculateOverallPerformance()
        {
            if (this.Components.Count == 0)
            {
                return base.OverallPerformance;
            }

            double result = base.OverallPerformance + this.Components.Average(x => x.OverallPerformance);
            return result;
        }
    }
}
