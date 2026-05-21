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
        public double TotalPoints { get; private set; }
        public Dictionary<string, double> CompletedAssignments { get; set; } = new();

        public Student(string name)
        {
            Name = name;
        }

        public Student(string name,  int lecturesAttended, int labsAttended)
        {
            Name = name;
            LecturesAttended = lecturesAttended;
            LabsAttended = labsAttended;
        }

        public void AssignGrade(string assignmentName, double points)
        {
            CompletedAssignments.Add(assignmentName, points);
            TotalPoints += points;
            Console.WriteLine($"Студент {Name} отримав {points} балів за {assignmentName}. Сума балів: {TotalPoints}");
        }
    }
}