using System;
using System.Text;

namespace Student_Progress_Tracker
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Student student1 = new Student("Вадим");
            Student student2 = new Student("Єлизавета");
            GradeBook gradeBook = new GradeBook();

            gradeBook.AddStudent(student1);
            gradeBook.AddStudent(student2);

            gradeBook.MarkAttendance("Вадим", "Лекція", true);
            gradeBook.MarkAttendance("Вадим", "Лабораторна", true);
            gradeBook.MarkAttendance("Єлизавета", "Лекція", false);
            gradeBook.MarkAttendance("Єлизавета", "Лабораторна", true);
        }
    }
}