using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Progress_Tracker
{
    internal class GradeBook
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void MarkAttendance(string studentName, string lessonType, bool isPresent)
        {
            var student = students.FirstOrDefault(student => student.Name == studentName);
            if (student != null && isPresent)
            {
                if (lessonType == "Лекція") student.LecturesAttended++;
                else if (lessonType == "Лабораторна") student.LabsAttended++;
                Console.WriteLine($"Журнал: {studentName} присутній/ня на {lessonType}");
            }
            else if (student != null && !isPresent)
            {
                Console.WriteLine($"Журнал: {studentName} відсутній/ня на {lessonType}");
            }
        }
    }
}