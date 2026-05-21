using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Progress_Tracker
{
    internal class Discipline
    {
        public string Title { get; set; }
        public int TotalLectures { get; set; }
        public int TotalLabs { get; set; }
        public double MaxPoints { get; set; }

        public Discipline(string title)
        {
            Title = title;
        }

        public Discipline(string title, int totalLectures, int totalLabs, double maxPoints)
        {
            Title = title;
            TotalLectures = totalLectures;
            TotalLabs = totalLabs;
            MaxPoints = maxPoints;
        }
    }
}