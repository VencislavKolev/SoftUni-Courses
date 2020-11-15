﻿
namespace OnlineShop.Models.Products.Components
{
    public class PowerSupply : Component
    {
        private const double POWER_SUPPLY_MULTIPLIER = 1.05;

        public PowerSupply(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance, generation)
        {
            //this.OverallPerformance *= POWER_SUPPLY_MULTIPLIER;
        }
        public override double OverallPerformance => base.OverallPerformance * POWER_SUPPLY_MULTIPLIER;
    }
}
