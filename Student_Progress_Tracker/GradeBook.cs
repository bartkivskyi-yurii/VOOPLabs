using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Text.Json;

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

        public void SaveToDatabase(string filePath)
        {
            List<string> lines = new List<string>();

            foreach (var student in students)
            {
                string gradesStr = string.Join(",", student.CompletedAssignments.Select(x => $"{x.Key}:{x.Value}"));

                string line = $"{student.Name}; {student.LecturesAttended}; {student.LabsAttended}; {gradesStr}";
                lines.Add(line);
            }

            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Дані успішно збережено у базу даних");
        }

        public void LoadFromDatabase(string filePath)
        {
            if (!File.Exists(filePath)) return;

            students.Clear();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(';');
                string name = parts[0];
                int lectures = int.Parse(parts[1]);
                int labs = int.Parse(parts[2]);

                Student student = new Student(name, lectures, labs);

                if (parts.Length > 3 && !string.IsNullOrEmpty(parts[3]))
                {
                    string[] grades = parts[3].Split(',');
                    foreach (string grade in grades)
                    {
                        string[] gradeParts = grade.Split(':');
                        if (gradeParts.Length == 2)
                        {
                            string taskName = gradeParts[0].Trim();
                            double points = double.Parse(gradeParts[1].Trim());

                            student.RestoreGradeQuietly(taskName, points);
                        }
                    }
                }
                students.Add(student);
            }
            Console.WriteLine("Дані журналу успішно відновлено з бази даних");
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

        public void ExecuteAddStudent(string dbPath)
        {
            Console.Write("Введіть ім'я студента: ");
            string name = Console.ReadLine();

            AddStudent(new Student(name));
            Console.WriteLine($"Студента {name} додано.");

            SaveToDatabase(dbPath);
        }

        public void ExecuteShowAllStudents()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Журнал студентів із успішністю");
            Console.ResetColor();
            ShowAllStudents();
        }

        public void ExecuteMarkAttendance()
        {
            Console.WriteLine("Уведіть ім'я студента(ки): ");
            string attName = Console.ReadLine();

            string typeLecture = "Лекція";
            string typeLab = "Лабораторна";

            if (File.Exists("lessonType.json"))
            {
                string rawTypesFromFile = File.ReadAllText("lessonType.json");
                List<string> typesFromFile = JsonSerializer.Deserialize<List<string>>(rawTypesFromFile);

                if (typesFromFile != null && typesFromFile.Count >= 2)
                {
                    typeLecture = typesFromFile[0];
                    typeLab = typesFromFile[1];
                }
            }

            Console.WriteLine("Оберіть тип заняття:");
            Console.WriteLine($"1 - {typeLecture}");
            Console.WriteLine($"2 - {typeLab}");
            Console.Write("Ваш вибір (1 або 2): ");
            string typeChoice = Console.ReadLine();

            string lessonType = typeChoice == "2" ? typeLab : typeLecture;

            Console.Write("Студент присутній? (1 - Так, 0 - Ні): ");
            bool isPresent = Console.ReadLine() == "1";

            MarkAttendance(attName, lessonType, isPresent);
        }

        public void ExecuteRecordGrade(string dbPath)
        {
            Console.Write("Введіть ім'я студента: ");
            string gradeName = Console.ReadLine();

            string taskTitle = "";

            if (File.Exists("assignments.json"))
            {
                string rawAssignments = File.ReadAllText("assignments.json");
                List<string> assignments = JsonSerializer.Deserialize<List<string>>(rawAssignments);

                if (assignments != null && assignments.Count > 0)
                {
                    Console.WriteLine("\nОберіть роботу зі списку:");
                    for (int i = 0; i < assignments.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {assignments[i]}");
                    }

                    Console.WriteLine("Ваш вибір: ");
                    if (int.TryParse(Console.ReadLine(), out int choiceIndex) && choiceIndex >= 1 && choiceIndex <= assignments.Length)
                    {
                        taskTitle = assignments[choiceIndex - 1];
                    }
                    else
                    {
                        Console.WriteLine("Невірний вибір номера роботи.");
                        return;
                    }
                }
            }

            if (string.IsNullOrEmpty(taskTitle))
            {
                Console.WriteLine("Уведіть назву роботи вручну: ");
                taskTitle = Console.ReadLine();
            }

            Console.WriteLine($"Уведіть кількість балів за \"{taskTitle}\": ");
            if (double.TryParse(Console.ReadLine(), out double points) && points >= 0)
            {
                RecordGrade(gradeName, taskTitle, points);

                SaveToDatabase(dbPath);
            }
        }
    }
}