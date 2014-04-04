using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eksamen2014
{
    class InvalidRegistreringsnummerException : Exception
    {
        public InvalidRegistreringsnummerException() : base() { }
        public InvalidRegistreringsnummerException(string msg) : base(msg) { }
        public InvalidRegistreringsnummerException(string msg, Exception e) : base(msg, e) { }
    }
}
