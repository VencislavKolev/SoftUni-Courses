
using System;
using System.Collections.Generic;
using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private readonly Dictionary<string, IProcedure> procedures;
        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new Dictionary<string, IProcedure>();
            this.SeedProcedures();
        }
        public string Charge(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);

            IRobot robot = this.GetRobot(robotName);

            IProcedure procedure = this.procedures[nameof(this.Charge)];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Chip(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);
            IRobot robot = this.GetRobot(robotName);

            IProcedure procedure = this.procedures[nameof(this.Chip)];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string History(string procedureType)
        {
            IProcedure procedure = this.procedures[procedureType];

            return procedure.History();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;

            switch (robotType)
            {
                case "HouseholdRobot":
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case "PetRobot":
                    robot = new PetRobot(name, energy, happiness, procedureTime);
                    break;
                case "WalkerRobot":
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            this.garage.Manufacture(robot);

            return string.Format(OutputMessages.RobotManufactured, name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);
            IRobot robot = this.GetRobot(robotName);

            IProcedure procedure = this.procedures[nameof(this.Polish)];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);

            IRobot robot = this.GetRobot(robotName);

            IProcedure procedure = this.procedures[nameof(this.Rest)];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            this.CheckIfRobotExists(robotName);

            IRobot robot = this.GetRobot(robotName);
            this.garage.Sell(robotName, ownerName);
            if (robot.IsChipped)
            {
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);

            IRobot robot = this.GetRobot(robotName);

            IProcedure procedure = this.procedures[nameof(this.TechCheck)];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);

            IRobot robot = this.GetRobot(robotName);

            IProcedure procedure = this.procedures[nameof(this.Work)];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        private void CheckIfRobotExists(string robotName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
        }
        private IRobot GetRobot(string robotName)
        {
            return this.garage.Robots[robotName];
        }

        private void SeedProcedures()
        {
            this.procedures["Charge"] = new Charge();
            this.procedures["Chip"] = new Chip();
            this.procedures["Rest"] = new Rest();
            this.procedures["Work"] = new Work();
            this.procedures["Polish"] = new Polish();
            this.procedures["TechCheck"] = new TechCheck();
        }
    }
}
