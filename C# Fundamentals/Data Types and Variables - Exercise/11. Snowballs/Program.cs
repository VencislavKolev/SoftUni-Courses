using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger snowballs = BigInteger.Parse(Console.ReadLine());
            BigInteger highestSnowballValue = 0;

            BigInteger snowballSnowPrint = 0;
            BigInteger snowballTimePrint = 0;
            BigInteger snowballQualityPrint = 0;

            for (BigInteger i = 1; i <= snowballs; i++)
            {
                BigInteger snowballSnow = BigInteger.Parse(Console.ReadLine());
                BigInteger snowballTime = BigInteger.Parse(Console.ReadLine());
                BigInteger snowballQuality = BigInteger.Parse(Console.ReadLine());

                BigInteger snowballValue = (BigInteger)BigInteger.Pow(snowballSnow / snowballTime, (int)snowballQuality);

                if (snowballValue >= highestSnowballValue)
                {
                    highestSnowballValue = snowballValue;
                    snowballSnowPrint = snowballSnow;
                    snowballTimePrint = snowballTime;
                    snowballQualityPrint = snowballQuality;
                }
            }
            Console.WriteLine($"{ snowballSnowPrint} : { snowballTimePrint} = { highestSnowballValue} ({ snowballQualityPrint})");
        }
    }
}
