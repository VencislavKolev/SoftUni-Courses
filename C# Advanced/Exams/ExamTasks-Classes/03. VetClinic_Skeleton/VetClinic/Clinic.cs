
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private readonly ICollection<Pet> pets;
        private Clinic()
        {
            this.pets = new List<Pet>();
        }
        public Clinic(int capacity)
            :this()
        {
            this.Capacity = capacity;
        }
        public int Capacity { get; set; }
        public int Count => this.pets.Count;

        public void Add(Pet pet)
        {
            if (this.pets.Count < this.Capacity)
            {
                this.pets.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            Pet pet = this.pets.FirstOrDefault(x => x.Name == name);
            return this.pets.Remove(pet);
        }
        public Pet GetPet(string name, string owner)
        {
            Pet pet = this.pets
                .FirstOrDefault(p => p.Name == name &&
                p.Owner == owner);
            //if (pet == null)
            //{
            //    return null;
            //}
            return pet;
        }
        public Pet GetOldestPet()
        {
            Pet pet = this.pets
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();
            return pet;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The clinic has the following patients:");
            foreach (Pet pet in this.pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
