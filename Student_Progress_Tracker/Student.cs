using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Progress_Tracker
{
    internal class Student
    {
        private string name;
        private int lecturesAttended;
        private int labsAttended;
        private double totalPoints;
        private Dictionary<string, double> completedAssignments;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int LecturesAttended
        {
            get { return lecturesAttended; }
            set { lecturesAttended = value; }
        }

        public int LabsAttended
        {
            get { return labsAttended; }
            set { labsAttended = value; }
        }

        public double TotalPoints
        {
            get { return totalPoints; }
            private set { totalPoints = value; }
        }

        public Dictionary<string, double> CompletedAssignments
        {
            get { return completedAssignments; }
        }

        // Конструктор
        public Student(string name, int lectures = 0, int labs = 0)
        {
            Name = name;
            LecturesAttended = lectures;
            LabsAttended = labs;
            TotalPoints = 0;
            completedAssignments = new Dictionary<string, double>();
        }

        public void RestoreGradeQuietly(string assignmentName, double points)
        {
            if (!CompletedAssignments.ContainsKey(assignmentName))
            {
                CompletedAssignments.Add(assignmentName, points);
                TotalPoints += points;
            }
        }

        public void AssignGrade(string assignmentName, double points)
        {
            CompletedAssignments.Add(assignmentName, points);
            TotalPoints += points;
            Console.WriteLine($"Студент {Name} отримав {points} балів за {assignmentName}. Сума балів: {TotalPoints}");
        }
    }
}