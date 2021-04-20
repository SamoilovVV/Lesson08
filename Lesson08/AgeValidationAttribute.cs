using System;

namespace Lesson08
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class AgeValidationAttribute : Attribute
    {
        public int Age { get; set; }

        public AgeValidationAttribute()
        { }

        public AgeValidationAttribute(int age)
        {
            Age = age;
        }
    }
}
