using System;
using System.Text;
using System.IO;
using System.Text.Json;

namespace Student_Progress_Tracker
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string dbPath = "database.txt";

            Discipline oop;

            if (File.Exists("discipline.json"))
            {
                string jsonString = File.ReadAllText("discipline.json");
                oop = JsonSerializer.Deserialize<Discipline>(jsonString);
            }
            else
            {
                oop = new Discipline("Об'єктно-орієнтоване програмування", 16, 6, 100.0);
            }
            GradeBook gBook = new GradeBook(oop);

            bool isRunning = true;

            while (isRunning)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Журнал: {gBook.Course.Title}");

                if (File.Exists("menu.json"))
                {
                    string rawMenu = File.ReadAllText("menu.json");
                    List<string> menuLines = JsonSerializer.Deserialize<List<string>>(rawMenu);

                    foreach (string line in menuLines) Console.WriteLine(line);
                }
                
                Console.ResetColor();

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        gBook.ExecuteAddStudent(dbPath);
                        break;
                    case 2:
                        gBook.ExecuteShowAllStudents();
                        break;
                    case 3:
                        gBook.ExecuteMarkAttendance();
                        break;
                    case 4:
                        gBook.ExecuteRecordGrade(dbPath);
                        break;
                    case 5:
                        gBook.SaveToDatabase(dbPath);
                        break;
                    case 6:
                        gBook.LoadFromDatabase(dbPath);
                        break;
                    case 0:
                        Console.WriteLine("Завершення роботи");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Уводьте числа які зазнченні в меню для подальших дій.");
                        break;
                }
            }
        }
    }
}