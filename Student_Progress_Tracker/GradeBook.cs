using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Progress_Tracker
{
    internal class GradeBook
    {
        public Discipline Course { get; set; }

        public GradeBook(Discipline course)
        {
            Course = course;
        }

        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void ShowAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Журнал порожній.");
                return;
            }

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i].Name} | Лекції: {students[i].LecturesAttended}, Лаб: {students[i].LabsAttended} | Бали: {students[i].TotalPoints}");
            }
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

        public void RecordGrade(string studentName, string assignmentName, double points)
        {
            var student = students.FirstOrDefault(student => student.Name == studentName);
            if (student != null)
            {
                student.AssignGrade(assignmentName, points);
            }
            else
            {
                Console.WriteLine($"Студента(ки) з ім'ям {studentName} не знайдено.");
            }
        }
    }
}