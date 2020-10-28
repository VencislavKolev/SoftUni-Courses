using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace P06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private SortedSet<Person> sortedSet;
        private HashSet<Person> hashSet;
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo([AllowNull] Person otherPerson)
        {
            int result = 1;
            if (otherPerson != null)
            {
                result = this.Name.CompareTo(otherPerson.Name);
                if (result == 0)
                {
                    result = this.Age.CompareTo(otherPerson.Age);
                }
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                return this.Name == person.Name && this.Age == person.Age;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
    }

}
