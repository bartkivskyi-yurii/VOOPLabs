using System;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace Student_Progress_Tracker
{
    class Program
    {
        private static bool isRunning = true;

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string jsonPath = "discipline.json";
            List<Discipline> availableDisciplines = new List<Discipline>();

            if (File.Exists(jsonPath))
            {
                try
                {
                    string rawJson = File.ReadAllText(jsonPath);
                    availableDisciplines = JsonSerializer.Deserialize<List<Discipline>>(rawJson);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Не вдалося зчитати конфігурацію дисциплін: {ex.Message}");
                    return;
                }
            }

            if (availableDisciplines == null || availableDisciplines.Count == 0)
            {
                Console.WriteLine("Створюємо початковий шаблон файлу disciplines.json...");
                availableDisciplines = new List<Discipline>
                {
                    new Discipline("Об'єктно-орієнтоване програмування", 16, 6, 100.0),
                    new Discipline("Алгоритми та аналіз структур даних", 16, 6, 100.0),
                    new Discipline("Вища математика", 20, 10, 100.0)
                };

                var options = new JsonSerializerOptions { WriteIndented = true };
                string templateJson = JsonSerializer.Serialize(availableDisciplines, options);
                File.WriteAllText(jsonPath, templateJson);
            }

            Discipline selectedDiscipline = null;

            while (selectedDiscipline == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Оберіть дисципліну для роботи:");

                for (int i = 0; i < availableDisciplines.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {availableDisciplines[i].Title}");
                }
                Console.WriteLine("0 - Вийти з програми");
                Console.Write("\nВаш вибір: ");
                Console.ResetColor();

                string input = Console.ReadLine();

                if (input == "0")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Завершення роботи");
                    Console.ResetColor();
                    return;
                }

                if (int.TryParse(input, out int choiceIndex) && choiceIndex >= 1 && choiceIndex <= availableDisciplines.Count)
                {
                    selectedDiscipline = availableDisciplines[choiceIndex - 1];
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nНевірний вибір. Спробуйте ще раз.");
                    Console.ResetColor();
                    Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
                    Console.ReadKey();
                }
            }

            GradeBook gBook = new GradeBook(selectedDiscipline);

            List<string> menuLines = new List<string>();
            if (File.Exists("menu.json"))
            {
                menuLines = JsonSerializer.Deserialize<List<string>>(File.ReadAllText("menu.json"));
            }

            while (isRunning)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Журнал: {gBook.Course.Title}");
                Console.ResetColor();

                if (menuLines != null && menuLines.Count > 0)
                {
                    foreach (string line in menuLines) Console.WriteLine(line);
                }
                else
                {
                    Console.WriteLine("1. Додати студента\n2. Показати успішність\n3. Відмітити присутність\n4. Оцінити роботу\n0. Вийти");
                }

                Console.ResetColor();

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        gBook.ExecuteAddStudent(gBook.DbPath);
                        break;
                    case 2:
                        gBook.ExecuteShowAllStudents();
                        break;
                    case 3:
                        gBook.ExecuteMarkAttendance();
                        break;
                    case 4:
                        gBook.ExecuteRecordGrade(gBook.DbPath);
                        break;
                    case 5:
                        gBook.ExecutePreExamSummary();
                        break;
                    case 6:
                        gBook.ExecuteRecordExamGrade(gBook.DbPath);
                        break;
                    case 0:
                        ExitProgram(gBook);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Уводьте числа які зазнченні в меню для подальших дій.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        private static void ExitProgram(GradeBook gBook)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Завершення роботи");

            gBook.SaveToDatabase(gBook.DbPath);

            Console.ResetColor();
            isRunning = false;
        }
    }
}