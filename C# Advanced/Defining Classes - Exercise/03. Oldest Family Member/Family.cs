using DefiningClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private HashSet<Person> members;

        public Family()
        {
            this.members = new HashSet<Person>();
        }

        public void AddMember(Person member)
        {
            members.Add(member);
        }

        public Person GetOldestPerson()
        {
            Person oldestPerson = this.members
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();

            return oldestPerson;
        }
        
    }
}
