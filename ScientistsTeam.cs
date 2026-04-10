using System;
using System.Collections.Generic;
using System.Text;

namespace Barrtkivskyi_Lab5_VOOP
{
    internal class ScientistsTeam
    {
        private Scientist[] _scientist;
        public ScientistsTeam(int size)
        {
            _scientist = new Scientist[size];
        }
        public Scientist this[int index]
        {
            get
            {
                if (index >= 0 && index < _scientist.Length)
                {
                    return _scientist[index];
                }
                throw new IndexOutOfRangeException("Такого індексу науковця не існує");
            }
            set
            {
                if (index >= 0 && index < _scientist.Length)
                {
                    _scientist[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Такого індексу найковця не існує");
                }
            }
        }
        public int Length
        {
            get { return _scientist.Length; }
        }
    }
}
