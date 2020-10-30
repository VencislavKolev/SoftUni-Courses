
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> rabbits;
        private Cage()
        {
            this.rabbits = new List<Rabbit>();
        }
        public Cage(string name, int capacity)
            : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.rabbits.Count;
        public void Add(Rabbit rabbit)
        {
            if (this.rabbits.Count < this.Capacity)
            {
                this.rabbits.Add(rabbit);
            }
        }
        public bool RemoveRabbit(string name)
        {
            Rabbit rabbit = this.rabbits
                .FirstOrDefault(x => x.Name == name);
            return this.rabbits.Remove(rabbit);
        }
        public void RemoveSpecies(string species)
        {
            this.rabbits.RemoveAll(x => x.Species == species);
        }
        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = this.rabbits
                .FirstOrDefault(x => x.Name == name);
            rabbit.Available = false;
            return rabbit;
        }
        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            List<Rabbit> soldRabbits = new List<Rabbit>();
            foreach (Rabbit rabbit in this.rabbits
                .Where(x=>x.Species==species))
            {
                rabbit.Available = false;
                soldRabbits.Add(rabbit);
            }
            return soldRabbits.ToArray();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {this.Name}:");
            foreach (Rabbit rabbit in this.rabbits
                .Where(x=>x.Available==true))
            {
                sb.AppendLine(rabbit.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
