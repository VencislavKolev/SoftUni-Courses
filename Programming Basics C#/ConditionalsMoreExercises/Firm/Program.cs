using System;

namespace Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int HoursNeeded = int.Parse(Console.ReadLine());
            int Days = int.Parse(Console.ReadLine());
            double OvertimeWorkers= int.Parse(Console.ReadLine());

            double WorkHours = (Days * 0.9) * 8;
            double overtime = (OvertimeWorkers * 2 * Days);
            double totalHours = Math.Floor(WorkHours + overtime);

            if (totalHours>=HoursNeeded)
            {
                Console.WriteLine($"Yes!{Math.Floor(totalHours-HoursNeeded)} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{Math.Floor(HoursNeeded-totalHours)} hours needed.");
            }
        }
    }
}
