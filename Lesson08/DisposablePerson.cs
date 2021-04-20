using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson08
{
    public class DisposablePerson : IDisposable
    {
        private bool _disposed = false;
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return Name + ", " + Age.ToString();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~DisposablePerson()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Console.Beep();
                    Console.WriteLine("Disposed");
                }

                _disposed = true;
            }
        }
    }
}
