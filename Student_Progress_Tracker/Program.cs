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

            Discipline oop = new Discipline("Об'єктно-орієнтоване програмування", 16, 16, 100.0);
            GradeBook gBook = new GradeBook(oop);

            bool isRunning = true;

            while (isRunning)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Головне меню:");
                Console.WriteLine($"Журнал: {gBook.Course.Title}");
                Console.WriteLine("1 - Додати нового студента");
                Console.WriteLine("2 - Показати список студентів (з балами)");
                Console.WriteLine("3 - Відмітити присутність студента(ки)");
                Console.WriteLine("4 - Оцінити завдання / активність");
                Console.WriteLine("0 - Вийти");
                Console.WriteLine("Оберіть дію: ");
                Console.ForegroundColor = ConsoleColor.White;

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Введіть ім'я студента: ");
                        string name = Console.ReadLine();

                        gBook.AddStudent(new Student(name));
                        Console.WriteLine($"Студента {name} додано.");
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Журнал студентів із успішністю");
                        Console.ForegroundColor = ConsoleColor.White;
                        gBook.ShowAllStudents();
                        break;
                    case 3:
                        Console.WriteLine("Уведіть ім'я студента(ки): ");
                        string attName = Console.ReadLine();

                        Console.WriteLine("Оберіть тип заняття:");
                        Console.WriteLine("1 - Лекція");
                        Console.WriteLine("2 - Лабораторна");
                        Console.Write("Ваш вибір (1 або 2): ");
                        string typeChoice = Console.ReadLine();

                        string lessonType = typeChoice == "2" ? "Лабораторна" : "Лекція";

                        Console.Write("Студент присутній? (1 - Так, 0 - Ні): ");
                        bool isPresent = Console.ReadLine() == "1";

                        gBook.MarkAttendance(attName, lessonType, isPresent);
                        break;
                    case 4:
                        Console.Write("Введіть ім'я студента: ");
                        string gradeName = Console.ReadLine();

                        Console.Write("Введіть назву роботи (напр., Лаб 1): ");
                        string taskTitle = Console.ReadLine();

                        Console.Write("Введіть кількість отриманих балів: ");
                        if (double.TryParse(Console.ReadLine(), out double points))
                        {
                            gBook.RecordGrade(gradeName, taskTitle, points);
                        }
                        else
                        {
                            Console.WriteLine("Некоректне значення балів. Введіть число.");
                        }
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