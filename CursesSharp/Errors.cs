using System;

namespace CursesSharp
{
    public class CursesException : ApplicationException
    {
        public CursesException()
        {
        }

        public CursesException(string message)
            : base(message)
        {
        }

        public CursesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
