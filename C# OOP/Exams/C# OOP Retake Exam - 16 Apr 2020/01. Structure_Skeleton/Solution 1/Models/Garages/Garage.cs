
using System;
using System.Collections.Generic;

using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;
using RobotService.Models.Garages.Contracts;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int MAX_CAPACITY = 10;
        private readonly Dictionary<string, IRobot> robots;
        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }
        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public void Manufacture(IRobot robot)
        {
            if (this.robots.Count == MAX_CAPACITY)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            if (this.robots.ContainsKey(robot.Name))
            {
                string excMsg = string.Format(ExceptionMessages.ExistingRobot, robot.Name);
                throw new ArgumentException(excMsg);
            }
            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                string excMsg = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(excMsg);
            }
            IRobot robot = this.robots[robotName];
            robot.Owner = ownerName;
            robot.IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}
