
using System;
using System.Collections.Generic;
using System.Linq;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects.Food;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';

        private Wall wall;
        private List<Food.Food> foods;
        private Queue<Point> snakeParts;

        private int nextTopY;
        private int nextLeftX;
        private int foodIndex;
        public Snake(Wall wall)
        {
            this.wall = wall;
            this.foods = new List<Food.Food>();
            this.snakeParts = new Queue<Point>();
            this.foodIndex = this.RandomFoodNumber;

            this.GetFoods();
            this.CreateSnake();
        }

        public int PlayerLevel => this.snakeParts.Count;
        public int PlayerPoints { get; private set; }
        private int RandomFoodNumber => new Random().Next(0, this.foods.Count);
        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                Point point = new Point(2, topY);
                this.snakeParts.Enqueue(point);
            }
        }
        private void GetFoods()
        {
            this.foods.Add(new FoodHash(this.wall));
            this.foods.Add(new FoodDollar(this.wall));
            this.foods.Add(new FoodAsterisk(this.wall));
        }
        public bool IsMoving(Point direction)
        {
            Point snakeHead = this.snakeParts.Last();

            this.GetNextPoint(direction, snakeHead);

            bool isPointOfSnake = this.snakeParts
                .Any(x => x.LeftX == this.nextLeftX &&
                           x.TopY == this.nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);

            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.snakeParts.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if (this.foods[this.foodIndex].isFoodPoint(snakeNewHead))
            {
                this.Eat(direction, snakeNewHead);
            }

            Point snakeTail = this.snakeParts.Dequeue();
            snakeTail.Draw(' ');

            return true;
        }

        private void Eat(Point direction, Point currSnakeHead)
        {
            int length = this.foods[foodIndex].FoodPoints;
            this.PlayerPoints += length;
            for (int i = 0; i < length; i++)
            {
                this.snakeParts.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                GetNextPoint(direction, currSnakeHead);
            }
            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomFoodPosition(this.snakeParts);
        }

        private void GetNextPoint(Point direction,Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }
       
    }
}
