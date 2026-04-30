using System;
using System.Collections.Generic;
using System.Text;

namespace Bartkivskyi_Lab6_VOOP
{
    internal class CarMalfunctionException : Exception
    {
        public CarMalfunctionException(string message) : base(message)
        {
        }
    }
}