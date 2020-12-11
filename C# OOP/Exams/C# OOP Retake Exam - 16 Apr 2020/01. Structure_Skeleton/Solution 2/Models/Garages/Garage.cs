
using System;
using System.Collections.Generic;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int maxCapacity = 10;

        private readonly Dictionary<string, IRobot> robots;
        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public int Capacity { get; private set; }
        public IReadOnlyDictionary<string, IRobot> Robots
            => this.robots;

        public void Manufacture(IRobot robot)
        {
            if (this.Capacity >= maxCapacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            if (this.Robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }
            this.robots.Add(robot.Name, robot);
            this.Capacity++;
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot robot = this.Robots[robotName];
            robot.Owner = ownerName;
            robot.IsBought = true;

            this.robots.Remove(robotName);
            this.Capacity--;
        }
    }
}
