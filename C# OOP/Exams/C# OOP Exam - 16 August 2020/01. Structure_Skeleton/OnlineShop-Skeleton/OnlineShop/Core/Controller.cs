using System;
using System.Linq;
using System.Collections.Generic;

using OnlineShop.Common.Enums;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IComputer> computers;
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;
        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckIfNonExisitngComputerId(computerId);
            CheckIfComponentWithIdExists(id);
            ComponentType currComponentType = CheckIfValidComponentType(componentType);

            IComponent component = CreateValidComponent(id, manufacturer, model, price, overallPerformance, generation, currComponentType);

            IComputer computer = this.computers.First(x => x.Id == computerId);

            computer.AddComponent(component);
            this.components.Add(component);

            string res = string.Format(SuccessMessages.AddedComponent, currComponentType, id, computerId);
            return res;

        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            if (!Enum.TryParse(computerType, out ComputerType currType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            IComputer computer = CreateComputer(id, manufacturer, model, price, currType);

            this.computers.Add(computer);

            string res = string.Format(SuccessMessages.AddedComputer, id);
            return res;
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckIfNonExisitngComputerId(computerId);
            CheckIfPeripheralWithIdExists(id);
            PeripheralType currPeripheralType = CheckIfValidPeripheralType(peripheralType);

            IPeripheral peripheral = CreateValidPeripheral(id, manufacturer, model, price, overallPerformance, connectionType, currPeripheralType);

            IComputer computer = this.computers.First(x => x.Id == computerId);

            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            string res = string.Format(SuccessMessages.AddedPeripheral, currPeripheralType, id, computerId);
            return res;
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = this.computers
                 .Where(x => x.Price <= budget)
                 .OrderByDescending(x => x.OverallPerformance)
                 .FirstOrDefault();

            if (computer == null)
            {
                string excMsg = string.Format(ExceptionMessages.CanNotBuyComputer, budget);
                throw new ArgumentException(excMsg);
            }

            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            CheckIfNonExisitngComputerId(id);
            IComputer computer = this.computers.First(x => x.Id == id);
            this.computers.Remove(computer);

            string res = computer.ToString();
            return res;
        }

        public string GetComputerData(int id)
        {
            CheckIfNonExisitngComputerId(id);
            IComputer computer = this.computers.First(x => x.Id == id);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckIfNonExisitngComputerId(computerId);
            IComputer computer = this.computers.First(x => x.Id == computerId);

            IComponent removedComponent = computer.RemoveComponent(componentType);

            if (removedComponent == null)
            {
                string excMsg = string.Format(ExceptionMessages.NotExistingComponent, componentType, computer.GetType().Name, computerId);

                throw new ArgumentException(excMsg);
            }

            this.components.Remove(removedComponent);

            string res = string.Format(SuccessMessages.RemovedComponent, componentType, removedComponent.Id);
            return res;
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfNonExisitngComputerId(computerId);
            IComputer computer = this.computers.First(x => x.Id == computerId);

            IPeripheral removedPeripheral = computer.RemovePeripheral(peripheralType);

            if (removedPeripheral == null)
            {
                string excMsg = string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, computer.GetType().Name, computerId);

                throw new ArgumentException(excMsg);
            }

            this.peripherals.Remove(removedPeripheral);

            string res = string.Format(SuccessMessages.RemovedPeripheral, peripheralType, removedPeripheral.Id);
            return res;
        }


        private IPeripheral CreateValidPeripheral(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType, PeripheralType currPeripheralType)
        {
            IPeripheral peripheral = null;
            switch (currPeripheralType)
            {
                case PeripheralType.Headset:
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Keyboard:
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Monitor:
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Mouse:
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
            }
            return peripheral;
        }

        private void CheckIfPeripheralWithIdExists(int id)
        {
            if (this.peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
        }
        private static PeripheralType CheckIfValidPeripheralType(string peripheralType)
        {
            if (!Enum.TryParse(peripheralType, out PeripheralType currPeripheralType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            return currPeripheralType;
        }
        private static IComputer CreateComputer(int id, string manufacturer, string model, decimal price, ComputerType currType)
        {
            IComputer computer = null;
            switch (currType)
            {
                case ComputerType.DesktopComputer:
                    computer = new DesktopComputer(id, manufacturer, model, price);
                    break;
                case ComputerType.Laptop:
                    computer = new Laptop(id, manufacturer, model, price);
                    break;
            }

            return computer;
        }
        private static ComponentType CheckIfValidComponentType(string componentType)
        {
            if (!Enum.TryParse(componentType, out ComponentType currComponentType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            return currComponentType;
        }

        private static IComponent CreateValidComponent(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation, ComponentType currComponentType)
        {
            IComponent component = null;
            switch (currComponentType)
            {
                case ComponentType.CentralProcessingUnit:
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.Motherboard:
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.PowerSupply:
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.RandomAccessMemory:
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.SolidStateDrive:
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.VideoCard:
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
            }

            return component;
        }

        private void CheckIfComponentWithIdExists(int id)
        {
            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
        }

        private void CheckIfNonExisitngComputerId(int computerId)
        {
            if (!this.computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
