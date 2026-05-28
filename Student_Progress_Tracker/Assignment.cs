using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Progress_Tracker
{
    internal class Assignment
    {
        private string title;
        private string type;
        private double maxPoints;
        private DateTime deadline;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public double MaxPoints
        {
            get { return maxPoints; }
            set { maxPoints = value; }
        }

        public DateTime Deadline
        {
            get { return deadline; }
            set { deadline = value; }
        }

        public Assignment(string title, string type, double maxPoints, DateTime deadline)
        {
            Title = title;
            Type = type;
            MaxPoints = maxPoints;
            Deadline = deadline;
        }
    }
}