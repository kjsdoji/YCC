using System;
using System.Collections.Generic;
using System.Text;

namespace YCC.Utilities.Exceptions
{
    public class YCCException : Exception
    {
        public YCCException()
        {
        }

        public YCCException(string message)
            : base(message)
        {
        }

        public YCCException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
