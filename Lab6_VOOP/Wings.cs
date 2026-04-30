using System;
using System.Collections.Generic;
using System.Text;

namespace Bartkivskyi_Lab6_VOOP
{
    internal class Wings
    {
        public bool IsExtended {  get; private set; }
        public void Extend()
        {
            IsExtended = true;
            Console.WriteLine("Крила висунуто\n");
        }
        public void Retract()
        {
            IsExtended = false;
            Console.WriteLine("Крила сховано\n");
        }
    }
}