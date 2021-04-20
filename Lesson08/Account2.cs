using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson08
{
    public partial class Account
    {
        public void Take(int sum)
        {
            CurrentSum -= sum;
        }

        partial void DoSomethingElse()
        {
            Console.WriteLine(CurrentSum);
        }
    }
}
