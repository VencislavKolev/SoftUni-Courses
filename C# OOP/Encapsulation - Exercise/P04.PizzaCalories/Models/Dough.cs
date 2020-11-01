using P04.PizzaCalories.Common;
using System;

namespace P04.PizzaCalories.Models
{
    public class Dough
    {
        private const double BASE_DOUGH_CALORIES = 2;
        private const double WHITE_DOUGH_CALORIES = 1.5;
        private const double WHOLEGRAIN_DOUGH_CALORIES = 1;

        private const double CRISPY_CALORIES = 0.9;
        private const double CHEWY_CALORIES = 1.1;
        private const double HOMEMADE_CALORIES = 1;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return this.flourType; }
            private set
            {
                string flour = value.ToLower();
                if (flour != "white" && flour != "wholegrain")
                {
                    throw new ArgumentException(GlobalConstants.InvalidDoughTypeMessage);
                }
                this.flourType = value.ToLower();
            }
        }
        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                string technique = value.ToLower();
                if (technique != "crispy" && technique != "chewy" && technique != "homemade")
                {
                    throw new ArgumentException(GlobalConstants.InvalidDoughTypeMessage);
                }
                this.bakingTechnique = value.ToLower();
            }
        }
        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(GlobalConstants.InvalidDoughWeightMessage);
                }
                this.weight = value;
            }
        }
        public double Calories
        {
            get { return this.CalculateCalories(); }
        }
        private double CalculateCalories()
        {
            double flourTypeModifier = 0;
            switch (this.FlourType)
            {
                case "white": flourTypeModifier = WHITE_DOUGH_CALORIES; break;
                case "wholegrain": flourTypeModifier = WHOLEGRAIN_DOUGH_CALORIES; break;
            }
            double bakingTechniqueModifier = 0;
            switch (this.BakingTechnique)
            {
                case "crispy": bakingTechniqueModifier = CRISPY_CALORIES; break;
                case "chewy": bakingTechniqueModifier = CHEWY_CALORIES; break;
                case "homemade": bakingTechniqueModifier = HOMEMADE_CALORIES; break;
            }
            return (BASE_DOUGH_CALORIES * this.Weight) * flourTypeModifier * bakingTechniqueModifier;
        }
    }
}
