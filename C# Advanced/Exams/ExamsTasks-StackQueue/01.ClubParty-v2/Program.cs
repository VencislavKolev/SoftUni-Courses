using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ClubParty
{
    public class Hall
    {
        public Hall()
        {
            this.Reservations = new List<int>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<int> Reservations { get; set; }
        public override string ToString()
        {
            return $"{this.Name} -> {string.Join(", ", this.Reservations)}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>(Console.ReadLine().Split());
            Queue<Hall> halls = new Queue<Hall>();

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                int people;
                if (int.TryParse(current, out people))
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }
                    Hall hall = halls.Peek();
                    if (hall.Capacity - people >= 0)
                    {
                        hall.Capacity -= people;
                        hall.Reservations.Add(people);
                    }
                    else
                    {
                        Console.WriteLine(hall);
                        halls.Dequeue();
                        if (halls.Any())
                        {
                            Hall newHall = halls.Peek();
                            newHall.Capacity -= people;
                            newHall.Reservations.Add(people);
                        }
                    }
                }
                else
                {
                    //Adding to the Queue<Hall> all halls from the stack
                    halls.Enqueue(new Hall()
                    {
                        Capacity = capacity,
                        Name = current
                    });
                }
            }
        }
    }
}
