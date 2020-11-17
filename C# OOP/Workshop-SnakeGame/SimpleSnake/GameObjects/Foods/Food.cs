
using System;
using System.Linq;
using System.Collections.Generic;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private readonly char foodSymbol;
        private readonly Wall wall;
        private readonly Random random;

        public Food(Wall wall, char foodSymbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            this.FoodPoints = points;
            this.random = new Random();
        }
        public int FoodPoints { get; }

        public void SetRandomFoodPosition(Queue<Point> snakeElements)
        {
            bool isPointOfSnake = true;

            while (isPointOfSnake)
            {
                this.LeftX = random.Next(2, wall.LeftX - 2);
                this.TopY = random.Next(2, wall.TopY - 2);

                isPointOfSnake = snakeElements
                    .Any(x => x.LeftX == this.LeftX &&
                              x.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }
        public bool IsFoodPoint(Point snake)
        {
            return snake.TopY == this.TopY &&
                   snake.LeftX == this.LeftX;
        }
    }
}
