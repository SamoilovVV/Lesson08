using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson08
{
    class DynamicPerson
    {
        public string Name { get; set; }
        public dynamic Age { get; set; }

        // выводим зарплату в зависимости от переданного формата
        public dynamic GetSalary(dynamic value, string format)
        {
            if (format == "string")
            {
                return value + " рублей";
            }
            else if (format == "int")
            {
                return value;
            }
            else
            {
                return 0.0;
            }
        }

        public override string ToString()
        {
            return Name + ", " + Age.ToString();
        }
    }
}
