
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects.Food
{
    public abstract class Food : Point
    {
        private char foodSymbol;
        private Wall wall;
        private Random random;

        public Food(Wall wall, char foodSymbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            this.FoodPoints = points;
            this.random = new Random();
        }
        public int FoodPoints { get; private set; }

        public void SetRandomFoodPosition(Queue<Point> snakeElements)
        {
            bool isPointOfSnake = GenerateRandomFoodPosition(snakeElements);

            while (isPointOfSnake)
            {
                isPointOfSnake = GenerateRandomFoodPosition(snakeElements);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }
        public bool isFoodPoint(Point snake)
        {
            return snake.TopY == this.TopY &&
                   snake.LeftX == this.LeftX;
        }
        private bool GenerateRandomFoodPosition(Queue<Point> snakeElements)
        {
            this.LeftX = random.Next(2, wall.LeftX - 2);
            this.TopY = random.Next(2, wall.TopY - 2);

            bool isPointOfSnake = snakeElements
                .Any(x => x.LeftX == this.LeftX &&
                          x.TopY == this.TopY);
            return isPointOfSnake;
        }
    }
}
