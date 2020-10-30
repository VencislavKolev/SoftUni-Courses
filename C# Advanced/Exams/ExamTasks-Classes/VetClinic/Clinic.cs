using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private HashSet<Pet> pets;
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.pets = new HashSet<Pet>();
        }
        public int Capacity { get; set; }
        public int Count
        {
            get { return this.pets.Count; }
        }
        public void Add(Pet pet)
        {
            if (this.pets.Count < this.Capacity)
            {
                this.pets.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            Pet pet = this.pets
                .FirstOrDefault(x => x.Name == name);
            if (pet != null)
            {
                this.pets.Remove(pet);
                return true;
            }
            return false;
        }
        public Pet GetPet(string name, string owner)
        {
            Pet pet = this.pets
                .FirstOrDefault(x => x.Name == name && x.Owner == owner);
            if (pet != null)
            {
                return pet;
            }
            return null;
        }
        public Pet GetOldestPet()
        {
            return this.pets
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in this.pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
