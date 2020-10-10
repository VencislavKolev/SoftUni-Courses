using System;

namespace _01._Experience_Gaining
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int battleCount = int.Parse(Console.ReadLine());
            double currExperience = 0;
            bool isEnough = false;
            int battle = 0;
            for (int currBattle = 1; currBattle <= battleCount; currBattle++)
            {
                double experienceEarnedPerBattle = double.Parse(Console.ReadLine());
                battle++;
                if (currBattle % 3 == 0)
                {
                    currExperience += experienceEarnedPerBattle * 1.15;
                }
                else if (currBattle % 5 == 0)
                {
                    currExperience += experienceEarnedPerBattle * 0.90;
                }
                else
                {
                    currExperience += experienceEarnedPerBattle;
                }
                if (currExperience >= neededExperience)
                {
                    isEnough = true;
                    break;
                }
            }
            if (isEnough == true)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battle} battles.");
            }
            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {neededExperience - currExperience:f2} more needed.");
            }
        }
    }
}
