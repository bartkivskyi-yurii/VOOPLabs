using System;
using System.Collections.Generic;
using System.Text;

namespace Bartkivskyi_Lab4_VOOP_Part4
{
    internal class AgeAndSalaryComparer : IComparer<Worker>
    {
        public int Compare(Worker x, Worker y)
        {
            if (x == null && y == null) return 0;

            int ageComparison = x.Age.CompareTo(y.Age);

            if (ageComparison != 0)
            {
                return ageComparison;
            }

            return x.Salary.CompareTo(y.Salary);
        }
    }
}