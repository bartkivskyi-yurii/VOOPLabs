using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Bartkivskyi_Lab3_VOOP
{
    partial class Student
    {
        private string firstName;
        private string lastName;
        private string educationalProgram;
        private int yearOfStudy;
        private double rating;
        public Student()
        {
            firstName = "";
            lastName = "";
            educationalProgram = "";
            yearOfStudy = 0;
            rating = 0.0;
        }
        public Student(string firstName, string lastName, string educationalProgram, int yearOfStudy, double rating)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.educationalProgram = educationalProgram;
            this.yearOfStudy = yearOfStudy;
            this.rating = rating;
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string EducationalProgram
        {
            get { return educationalProgram; }
            set { educationalProgram = value; }
        }
        public int YearOfStudy
        {
            get { return yearOfStudy; }
            set { yearOfStudy = value; }
        }
        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }
        public void InputFromConsole()
        {
            Console.WriteLine("Уведіть ім'я студента: ");
            FirstName = Console.ReadLine();

            Console.WriteLine("\nУведіть прізвище студента: ");
            LastName = Console.ReadLine();

            Console.WriteLine("\nУведіть освітню програму: ");
            EducationalProgram = (Console.ReadLine());

            Console.WriteLine("\nУведіть рік навчання (курс) студента: ");
            YearOfStudy = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nУведіть рейтинг студента: ");
            Rating = Convert.ToDouble(Console.ReadLine());
        }
        public void PrintToConsole()
        {
            Console.WriteLine($"\nІм'я студента: {FirstName}");
            Console.WriteLine($"Прізвище студента: {LastName}");
            Console.WriteLine($"Освітня програма: {EducationalProgram}");
            Console.WriteLine($"Рік навчання (курс): {YearOfStudy}");
            Console.WriteLine($"Рейтинг: {Rating}\n");
        }
        public void CalculateRating()
        {
            Random rnd = new Random();
            double sum = 0.0;

            Console.WriteLine("Оцінки студента: ");
            for (int i = 0; i < 10; i++)
            {
                int grade = rnd.Next(1, 101);
                Console.WriteLine(grade + ", ");
                sum += grade;
            }
            Console.WriteLine();

            Rating = sum / 10;
            Console.WriteLine($"Рейтинг студента: {Rating}");
        }
        public void SaveToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine($"{FirstName} {LastName}, {EducationalProgram}, {YearOfStudy}, {Rating}");
            }
            Console.WriteLine($"\nДані успішно збережено у файл {fileName}");
        }
    }
}