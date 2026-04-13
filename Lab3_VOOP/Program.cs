using System;
using System.Text;

namespace Bartkivskyi_Lab3_VOOP
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("\n====== Клас Department ======\n");

            Department dep = new Department("Кафедра програмних систем і технологій", 15, 200, "Інженерія програмного забезпечення", 'A');
            Console.WriteLine($"Студентів до акредитації: {dep.StudentsCount}");
            dep.StudentsByAccreditation();
            Console.WriteLine($"Студентів після акредитації: {dep.StudentsCount}");
            dep.SaveToFile("departments.txt");

            Console.WriteLine("\n====== КЛАСИ STUDENT ТА CONTESTWORK ======\n");

            Student stud = new Student("Іван", "Петренко", "Кафедра програмних систем і технологій", 3, 0.0);
            stud.CalculateRating();
            stud.SaveToFile("students.txt");
            Console.WriteLine($"Студента {stud.FirstName} {stud.LastName} успішно збережено у файл.");

            Student.ContestWork work = new Student.ContestWork( "Всеукраїнський конкурс ІТ", "Сучасний штучний інтелект", 4 );

            work.CheckRelavent("themes.txt");

            int qualityScore = work.CalculateQuality();
            Console.WriteLine($"\nКількість статей (апробація): {work.ArticlesCount}");
            Console.WriteLine($"Отримані бали за якість роботи: {qualityScore} з 10");

            Console.WriteLine("\n====== ТВОРЧЕ ЗАВДАННЯ ======\n");

            Console.WriteLine("--- 1. Генерація масиву ---");
            CreativeWork.GenerateArr(10, -5, 5);

            Console.WriteLine("--- 2. Сортування вставкою ---\n");
            CreativeWork.InsertionSort(CreativeWork.arr.Length, CreativeWork.arr);

            Console.WriteLine("\n--- 3. Перенесення нулів у кінець ---");
            CreativeWork.GenerateArr(10, -2, 2);
            CreativeWork.RearrangeArray();

            Console.WriteLine("\n--- 4. Перевірка балансу дужок ---");
            CreativeWork.CheckBrackets();


            Console.WriteLine("\n==================================================");
            Console.WriteLine("Роботу програми завершено. Натисніть Enter для виходу...");
            Console.ReadLine();
        }
    }
}