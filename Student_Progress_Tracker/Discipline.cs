using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Progress_Tracker
{
    internal class Discipline
    {
        private string title;
        private int totalLectures;
        private int totalLabs;
        private double maxPoints;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int TotalLectures
        {
            get { return totalLectures; }
            set { totalLectures = value; }
        }

        public int TotalLabs
        {
            get { return totalLabs; }
            set { totalLabs = value; }
        }

        public double MaxPoints
        {
            get { return maxPoints; }
            set { maxPoints = value; }
        }

        public Discipline() { }

        public Discipline(string title, int totalLectures, int totalLabs, double maxPoints)
        {
            Title = title;
            TotalLectures = totalLectures;
            TotalLabs = totalLabs;
            MaxPoints = maxPoints;
        }
    }
}