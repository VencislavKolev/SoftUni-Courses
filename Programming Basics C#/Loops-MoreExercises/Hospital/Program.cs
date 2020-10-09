using System;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());
            int treatedPatients = 0;
            int untreatedPatients = 0;
            int doctors = 7;

            for (int i = 1; i <= period; i++)
            {
                int numberOfPatients = int.Parse(Console.ReadLine());
                if (i % 3 == 0 && untreatedPatients > treatedPatients)
                {
                    doctors++;
                }
                if (numberOfPatients <= doctors)
                {
                    treatedPatients += numberOfPatients;
                }
                else if (numberOfPatients > doctors)
                {
                    
                    treatedPatients += doctors;
                    untreatedPatients += numberOfPatients - doctors;
                }
            }
            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untreatedPatients}.");
        }
    }
}
