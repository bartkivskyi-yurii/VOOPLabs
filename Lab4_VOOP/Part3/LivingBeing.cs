using System;
using System.Collections.Generic;
using System.Text;

namespace Bartkivskyi_Lab4_VOOP_Part3
{
    internal abstract class LivingBeing
    {
        public string Species { get; set; } = "Людина розумна";
        public void Breathe()
        {
            Console.WriteLine("Істота дихає");
        }
        public abstract void Think();
    }
}
