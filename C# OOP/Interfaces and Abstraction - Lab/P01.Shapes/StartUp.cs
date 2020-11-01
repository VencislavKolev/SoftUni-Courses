using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int circleRadius = int.Parse(Console.ReadLine());
            IDrawable circle = new Circle(circleRadius);
            circle.Draw();

            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            IDrawable rectangle = new Rectangle(width, height);
            rectangle.Draw();
        }
    }
}
