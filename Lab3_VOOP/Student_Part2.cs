using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Bartkivskyi_Lab3_VOOP
{
    public partial class Student
    {
        public partial class ContestWork
        {
            public int CalculateQuality()
            {
                if (ArticlesCount <= 0)
                {
                    return 0;
                }

                int score = 0;
                int d = 2;

                int n = ArticlesCount > 5 ? 5 : ArticlesCount;

                for (int i = 1; i <= n; i++)
                {
                    score += d;
                }
                return score;
            }
        }
    }
}