
namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';
        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            this.InitializeWallBorders();
        }

        public bool IsPointOfWall(Point snakeHead)
        {
            return snakeHead.LeftX == 0 ||
                   snakeHead.LeftX == this.LeftX - 1 ||
                   snakeHead.TopY == 0 ||
                   snakeHead.TopY == this.TopY;
        }

        private void InitializeWallBorders()
        {
            this.SetHorizontalLine(0);
            this.SetHorizontalLine(this.TopY);

            this.SetVerticalLine(0);
            this.SetVerticalLine(this.LeftX - 1);
        }
        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }
        private void SetVerticalLine(int leftX)
        {
            for (int currTopY = 0; currTopY < this.TopY; currTopY++)
            {
                this.Draw(leftX, currTopY, wallSymbol);
            }
        }
    }
}
