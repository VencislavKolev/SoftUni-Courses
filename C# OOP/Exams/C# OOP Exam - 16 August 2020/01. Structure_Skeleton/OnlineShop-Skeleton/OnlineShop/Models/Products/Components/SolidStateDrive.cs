﻿
namespace OnlineShop.Models.Products.Components
{
    public class SolidStateDrive : Component
    {
        private const double SSD_MULTIPLIER = 1.20;

        public SolidStateDrive(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance, generation)
        {
          //  this.OverallPerformance *= SSD_MULTIPLIER;
        }
        public override double OverallPerformance => base.OverallPerformance * SSD_MULTIPLIER;
    }
}
