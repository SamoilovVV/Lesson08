using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson08
{
    [AgeValidation(18)]
    public class User
    {
        private string _name;

        public string Name { get => _name; set => _name = value; }

        [AgeValidation(18)]
        public int Age { get; set; }
        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string GetVisibleName()
        {
            return $"{Name}: {Age}";
        }
    }
}
