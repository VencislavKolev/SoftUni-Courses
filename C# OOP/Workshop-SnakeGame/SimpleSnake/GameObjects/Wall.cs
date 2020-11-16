
namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';
        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            this.CreateLines();
        }

        private void CreateLines()
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
