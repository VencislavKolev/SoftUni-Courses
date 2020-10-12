using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();
            string reservationNumber = Console.ReadLine();
            while (reservationNumber != "PARTY")
            {
                if (char.IsDigit(reservationNumber[0]))
                {
                    vipGuests.Add(reservationNumber);
                }
                else
                {
                    regularGuests.Add(reservationNumber);
                }
                reservationNumber = Console.ReadLine();
            }
            string attendedGuest = Console.ReadLine();
            while (attendedGuest != "END")
            {
                if (char.IsDigit(attendedGuest[0]))
                {
                    vipGuests.Remove(attendedGuest);
                }
                else
                {
                    regularGuests.Remove(attendedGuest);
                }
                attendedGuest = Console.ReadLine();
            }
            int notAttendedRegularGuests = regularGuests.Count;
            int notAttendedVIPGuests = vipGuests.Count;
            Console.WriteLine(notAttendedVIPGuests + notAttendedRegularGuests);
            foreach (var vipGuest in vipGuests)
            {
                Console.WriteLine(vipGuest);
            }
            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
