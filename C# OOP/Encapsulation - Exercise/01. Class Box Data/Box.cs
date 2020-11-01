using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _01._Class_Box_Data
{
    public class Box
    {
        private const double MIN_SIDE_SIZE = 0;
        private const string INVALID_SIDE_MESSAGE = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return this.length; }
            private set
            {
                ValidateSide(value, nameof(this.Length));
                this.length = value;
            }
        }
        public double Width
        {
            get { return this.width; }
            private set
            {
                ValidateSide(value, nameof(this.Width));
                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                ValidateSide(value, nameof(this.Height));
                this.height = value;
            }
        }
        private void ValidateSide(double value, string sideName)
        {
            if (value <= MIN_SIDE_SIZE)
            {
                throw new ArgumentException(string.Format(INVALID_SIDE_MESSAGE, sideName));
            }
        }
        public double CalculateVolume()
        {
            return this.Length * this.Width * this.Height;
        }
        public double CalculateSurfaceArea()
        {
            return (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }
        public double CalculateLateralSurfaceArea()
        {
            return (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }
    }
}
