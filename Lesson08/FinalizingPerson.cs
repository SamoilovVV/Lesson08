using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson08
{
    public class FinalizingPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return Name + ", " + Age.ToString();
        }

        public FinalizingPerson(string name, int age)
        {
            Name = name;
            Age = age;
        }

        ~FinalizingPerson()
        {
            Console.Beep();
            Console.WriteLine("Disposed");
        }
    }
}
