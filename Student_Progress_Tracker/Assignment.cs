using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Progress_Tracker
{
    internal class Assignment
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public double MaxPoints { get; set; }
        public DateTime Deadline { get; set; }

        public Assignment(string title, string type, double maxPoints, DateTime deadline)
        {
            Title = title;
            Type = type;
            MaxPoints = maxPoints;
            Deadline = deadline;
        }
    }
}