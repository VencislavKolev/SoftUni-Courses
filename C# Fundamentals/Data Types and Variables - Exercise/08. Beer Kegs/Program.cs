using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            double biggestVolume = 0;
            string biggestKegModel = "";
            int kegQuantity = int.Parse(Console.ReadLine());
            for (int i = 1; i <= kegQuantity; i++)
            {
                double currentKegVolume = 0;
                string modelKeg = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                currentKegVolume = Math.PI * radius * radius * height;
                if (currentKegVolume >= biggestVolume)
                {
                    biggestVolume = currentKegVolume;
                    biggestKegModel = modelKeg;
                }
            }
            Console.WriteLine(biggestKegModel);
        }
    }
}
