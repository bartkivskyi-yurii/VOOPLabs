using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Progress_Tracker
{
    internal class Student
    {
        public string Name { get; set; }
        public int LecturesAttended { get; set; }
        public int LabsAttended { get; set; }

        public Student(string name)
        {
            Name = name;
        }
    }
}