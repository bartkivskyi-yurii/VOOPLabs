using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;

namespace Student_Progress_Tracker
{
    internal class GradeBook
    {
        public Discipline Course { get; set; }
        private List<Student> students = new List<Student>();

        public string DbPath { get; private set; }

        public GradeBook(Discipline course)
        {
            Course = course;

            DbPath = $"db_{course.Title}.txt";

            LoadFromDatabase(DbPath);
        }

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
            Console.WriteLine($"Дані дисципліни {Course.Title} успішно збережено у базу даних");
        }

        private void LoadFromDatabase(string filePath)
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
                var student = students[i];
                Console.WriteLine($"{i + 1}. {students[i].Name} | Лекції: {students[i].LecturesAttended}, Лаб: {students[i].LabsAttended} | Бали: {students[i].TotalPoints}");

                if (student.CompletedAssignments.Count > 0)
                {
                    Console.WriteLine("\tВиконані роботи: ");
                    foreach (var assignment in student.CompletedAssignments)
                    {
                        Console.WriteLine($"\t{assignment.Key}: {assignment.Value} балів");
                    }
                }
                else
                {
                    Console.WriteLine("Немає оцінених робіт");
                }
                Console.WriteLine(new string('-', 50));
            }
        }

        public void MarkAttendance(string studentName, string lessonType, bool isPresent)
        {
            var student = students.FirstOrDefault(student => student.Name == studentName);
            if (student != null && isPresent)
            {
                if (lessonType == "Лекція") student.LecturesAttended++;
                else if (lessonType == "Лабораторна") student.LabsAttended++;
                Console.WriteLine($"Журнал: {studentName} присутній(ня) на {lessonType}");
            }
            else if (student != null && !isPresent)
            {
                Console.WriteLine($"Журнал: {studentName} відсутній(ня) на {lessonType}");
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

        public void ExamResults()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" Результати іспиту (60 семестр / 40 іспит) \n");
            Console.ResetColor();

            if (students == null || students.Count == 0)
            {
                Console.WriteLine("Список студентів порожній. Немає даних для прогнозу.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine(new string('-', 88));
            Console.WriteLine($"| {"Студент",-20} | {"Поточні бали",-14} | {"Мін. на іспиті (для 60)",-23} | {"Макс. за предмет",-18} |");
            Console.WriteLine(new string('-', 88));

            foreach (var student in students)
            {
                double currentPoints = student.TotalPoints;

                double validSemesterPoints = currentPoints > 60 ? 60 : currentPoints;

                double maxPossible = validSemesterPoints + 40;

                string statusText;
                string examMinText;

                if (currentPoints < 36)
                {
                    statusText = "Недопуск";
                    examMinText = "—";
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    statusText = "Допущено";
                    examMinText = "24 бали";
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine($"| {student.Name,-20} | {currentPoints,15:F1} | {statusText,-12} | {examMinText,-15} | {maxPossible,12:F1} |");
                Console.ResetColor();
            }

            Console.WriteLine(new string('-', 92));
            Console.WriteLine("\nНатисніть будь-яку клавішу для повернення до меню...");
            Console.ReadKey();
        }

        private (double Points, bool IsAdmitted) CalculateExamStatus(Student student)
        {
            double points = student.CompletedAssignments.Values.Sum();
            bool lecturesOk = student.LecturesAttended >= (Course.TotalLectures * 0.5);
            bool labsOk = student.LabsAttended >= (Course.TotalLabs * 0.5);

            return (points, lecturesOk && labsOk && points >= 36.0);
        }

        public void ExecutePreExamSummary()
        {
            Console.Clear();
            string jsonPath = "summary_ui.json";
            SummaryUiStrings ui = File.Exists(jsonPath)
                ? JsonSerializer.Deserialize<SummaryUiStrings>(File.ReadAllText(jsonPath)) ?? new SummaryUiStrings()
                : new SummaryUiStrings();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=================================================================================");
            Console.WriteLine($"                 {ui.Title}\n Дисципліна: {Course.Title}");
            Console.WriteLine("=================================================================================");
            Console.WriteLine($"{ui.HeaderNo,-3} | {ui.HeaderName,-30} | {ui.HeaderLectures,-8} | {ui.HeaderLabs,-6} | {ui.HeaderPoints,-6} | {ui.HeaderStatus}");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.ResetColor();

            if (students.Count == 0) { Console.WriteLine($" {ui.EmptyMessage}\n================================================================================="); Console.ReadKey(); return; }

            for (int i = 0; i < students.Count; i++)
            {
                var student = students[i];
                var (points, isAdmitted) = CalculateExamStatus(student);

                Console.Write($"{i + 1,-3} | {student.Name,-30} | {student.LecturesAttended}/{Course.TotalLectures,-5} | {student.LabsAttended}/{Course.TotalLabs,-4} | {points,-6:F1} | ");

                Console.ForegroundColor = isAdmitted ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine(isAdmitted ? ui.StatusAdmitted : ui.StatusNotAdmitted);
                Console.ResetColor();
            }

            Console.WriteLine("=================================================================================");
            Console.WriteLine($"\n{ui.FooterMessage}");
            Console.ReadKey();
        }

        public void ExecuteAddStudent(string dbPath)
        {
            Console.Clear();
            Console.Write("Введіть ім'я студента(ки): ");
            string name = Console.ReadLine();

            AddStudent(new Student(name));
            Console.WriteLine($"Студента(ку) {name} додано.");

            SaveToDatabase(dbPath);
        }

        public void ExecuteShowAllStudents()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Журнал студентів із успішністю");
            Console.ResetColor();
            ShowAllStudents();
        }

        public void ExecuteMarkAttendance()
        {
            Console.Clear();
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

            Console.Write("Студент(ка) присутній(ня)? (1 - Так, 0 - Ні): ");
            bool isPresent = Console.ReadLine() == "1";

            MarkAttendance(attName, lessonType, isPresent);
        }

        public void ExecuteRecordGrade(string dbPath)
        {
            Console.Clear();
            Console.Write("Введіть ім'я студента(ки): ");
            string gradeName = Console.ReadLine();

            var student = students.FirstOrDefault(s => s.Name == gradeName);
            if (student == null)
            {
                Console.WriteLine($"Студента(ки) \"{gradeName}\" не знайдено.");
                return;
            }

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

                    Console.Write("Ваш вибір: ");
                    if (int.TryParse(Console.ReadLine(), out int choiceIndex) && choiceIndex >= 1 && choiceIndex <= assignments.Count)
                    {
                        taskTitle = assignments[choiceIndex - 1];
                    }
                }
            }

            if (string.IsNullOrEmpty(taskTitle))
            {
                Console.Write("Уведіть назву роботи вручну: ");
                taskTitle = Console.ReadLine();
            }

            Console.Write($"Уведіть кількість балів за \"{taskTitle}\": ");
            if (double.TryParse(Console.ReadLine(), out double points) && points >= 0)
            {
                List<string> tasksWithoutDeadline = new List<string>();
                string exceptionsPath = "noDeadline.json";

                if (File.Exists(exceptionsPath))
                {
                    try
                    {
                        string rawExceptions = File.ReadAllText(exceptionsPath);
                        tasksWithoutDeadline = JsonSerializer.Deserialize<List<string>>(rawExceptions) ?? new List<string>();
                    }
                    catch { }
                }
                bool skipDeadline = tasksWithoutDeadline.Any(t => t.Equals(taskTitle, StringComparison.OrdinalIgnoreCase));

                if (!skipDeadline)
                {
                    Console.WriteLine("Коли була здана робота?");
                    Console.WriteLine("1 - Точно вчасно");
                    Console.WriteLine("2 - Раніше дедлайну (+ бонус)");
                    Console.WriteLine("3 - Після дедлайну (- штраф)");
                    Console.WriteLine("Ваш вибір (1, 2 або 3): ");
                    string deadlineChoice = Console.ReadLine();

                    if (deadlineChoice == "2")
                    {
                        Console.Write("На скільки днів раніше дедлайну здана робота? ");
                        if (int.TryParse(Console.ReadLine(), out int daysEarly) && daysEarly > 0)
                        {
                            double bonusPerDay = 1.5;
                            double bonusTotal = daysEarly * bonusPerDay;
                            points += bonusTotal;

                            Console.WriteLine($"Бонус за ранню здачу: +{bonusTotal} балів. Всього за роботу: {points}");
                        }
                    }
                    else if (deadlineChoice == "3")
                    {
                        Console.Write("Скільки днів прострочено? ");
                        if (int.TryParse(Console.ReadLine(), out int daysLate) && daysLate > 0)
                        {
                            double penaltyPerDay = 1.5;
                            double penaltyTotal = daysLate * penaltyPerDay;
                            points -= penaltyTotal;

                            if (points < 0) points = 0;

                            Console.WriteLine($"Штраф за запізнення: -{penaltyTotal} балів. Всього за роботу: {points}");
                        }
                    }
                }

                RecordGrade(gradeName, taskTitle, points);

                Console.Write("\nСтудент(ка) виконував індивідуальні творчі/ініціативні роботи, брав участь у конференціях/конкурсах/олімпіадах тощо? (1 - Так, 0 - Ні): ");
                if (Console.ReadLine() == "1")
                {
                    Console.Write("Уведіть назву додаткової роботи (напр., Олімпіада): ");
                    string bonusActivity = Console.ReadLine();

                    Console.Write("Уведіть кількість бонусних балів: ");
                    if (double.TryParse(Console.ReadLine(), out double bonusPoints) && bonusPoints > 0)
                    {
                        RecordGrade(gradeName, $"{bonusActivity}", bonusPoints);
                    }
                }

                SaveToDatabase(dbPath);
            }
            else
            {
                Console.WriteLine("Некоректне значення балів.");
            }
        }

        public void ExecuteRecordExamGrade(string dbPath)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ВВЕДЕННЯ ОЦІНОК ЗА ІСПИТ ===\n");

                if (students == null || students.Count == 0)
                {
                    Console.WriteLine("Список студентів порожній.");
                    Console.ReadKey();
                    return;
                }

                for (int i = 0; i < students.Count; i++)
                {
                    double currentPoints = students[i].TotalPoints;
                    string status = currentPoints >= 36 ? "[Допущено]" : "[Недопуск]";

                    Console.Write($"{i + 1}. {students[i].Name,-20} - {currentPoints,4:F1} балів ");
                    Console.ForegroundColor = currentPoints >= 36 ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.WriteLine(status);
                    Console.ResetColor();
                }

                Console.Write("\nОберіть номер студента для введення оцінки (або 0 для повернення в меню): ");

                if (int.TryParse(Console.ReadLine(), out int studentIndex))
                {
                    if (studentIndex == 0)
                    {
                        return;
                    }

                    if (studentIndex >= 1 && studentIndex <= students.Count)
                    {
                        var student = students[studentIndex - 1];

                        if (student.TotalPoints < 36)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\nСтудента(ки) \"{student.Name}\" не допущено до іспиту (менше 36 балів за семестр).");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write($"\nУведіть бали за іспит для студента(ки) \"{student.Name}\" (від 0 до 40): ");

                            if (double.TryParse(Console.ReadLine().Replace('.', ','), out double examPoints) && examPoints >= 0 && examPoints <= 40)
                            {
                                if (examPoints < 24)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\nСтудент(ка) не набрав(ла) мінімальні 24 бали. Іспит вважається нескладеним.");
                                    Console.ResetColor();
                                }

                                student.AssignGrade("Іспит", examPoints);
                                SaveToDatabase(dbPath);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nОцінку за іспит успішно збережено!");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nНекоректне значення! Бали за іспит мають бути від 0 до 40.");
                                Console.ResetColor();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nСтудента(ки) з таким номером не існує.");
                    }
                }
                else
                {
                    Console.WriteLine("\nНекоректний ввід. Потрібно ввести число.");
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
            }
        }
    }
}