using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson08
{
    public partial class Account
    {
        public int CurrentSum { get; private set; }
        public Account(int sum)
        {
            CurrentSum = sum;
        }

        public void Put(int sum)
        {
            CurrentSum += sum;
        }

        partial void DoSomethingElse();

        public void DoSomething()
        {
            Console.WriteLine("Start");
            DoSomethingElse();
            Console.WriteLine("Finish");
        }
    }
}
