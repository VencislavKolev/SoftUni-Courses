using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public  int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

    }
}
