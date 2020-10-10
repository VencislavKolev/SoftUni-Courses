using System;

namespace _01.Giftbox_Coverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideSize = double.Parse(Console.ReadLine());
            int sheetsCount = int.Parse(Console.ReadLine());
            double coveredAreaOfSingleSheet = double.Parse(Console.ReadLine());
            double giftBoxArea = (sideSize * sideSize) * 6;

            double thirdSheetCount = sheetsCount / 3;
            double thirdSheetCoverArea = coveredAreaOfSingleSheet * 0.25;
            double coveredAreaByThirdSheets = thirdSheetCount * thirdSheetCoverArea;

            double coveredAreaByNormalSheets = (sheetsCount - thirdSheetCount) * coveredAreaOfSingleSheet;
            double totalCoveredArea = coveredAreaByNormalSheets + coveredAreaByThirdSheets;
            double percentage = totalCoveredArea / giftBoxArea * 100;
            Console.WriteLine($"You can cover {percentage:f2}% of the box.");
        }
    }
}
