using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Bartkivskyi_Lab3_VOOP
{
    internal class Department
    {
        private string departmentName;
        private int teachersCount;
        private int studentsCount;
        private string educationalProgram;
        private char accreditationGrade;
        public Department()
        {
            departmentName = "";
            teachersCount = 0;
            studentsCount = 0;
            educationalProgram = "";
            accreditationGrade = '\0';
        }
        public Department(string departmentName, int teachersCount, int studentsCount, string educationalProgram, char accreditationGrade)
        {
            this.departmentName = departmentName;
            this.teachersCount = teachersCount;
            this.studentsCount = studentsCount;
            this.educationalProgram = educationalProgram;
            this.accreditationGrade = accreditationGrade;
        }
        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }
        public int TeachersCount
        {
            get { return teachersCount; }
            set { teachersCount = value; }
        }
        public int StudentsCount
        {
            get{ return studentsCount; }
            set { studentsCount = value; }
        }
        public string EducationalProgram
        {
            get { return educationalProgram; }
            set { educationalProgram = value; }
        }
        public char AccreditationGrade
        {
            get { return accreditationGrade; }
            set { accreditationGrade = value; }
        }
        public void InputFromConsole()
        {
            Console.WriteLine("Уведіть назву кафедри: ");
            DepartmentName = Console.ReadLine();

            Console.WriteLine("\nУведіть кількість викладачів: ");
            TeachersCount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nУведіть кількість студентів: ");
            StudentsCount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nУведіть назву назву освітньої програми: ");
            EducationalProgram = Console.ReadLine();

            Console.WriteLine("\nУведіть оцінку з акредитації освітньої програми (A, B, E): ");
            AccreditationGrade = Convert.ToChar(Console.ReadLine());
        }
        public void PrintToConsole()
        {
            Console.WriteLine($"\nНазва кафедри: {DepartmentName}");
            Console.WriteLine($"Кількість викладачів: {TeachersCount}");
            Console.WriteLine($"Кількість студентів: {StudentsCount}");
            Console.WriteLine($"Назва освітньої програми: {EducationalProgram}");
            Console.WriteLine($"Оцінка з акредитації освітньої програми: {AccreditationGrade}\n");
        }
        public void SaveToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine($"{DepartmentName}, {TeachersCount}, {StudentsCount}, {EducationalProgram}, {AccreditationGrade}");
            }
            Console.WriteLine($"\nДані успішно збережено у файл {fileName}");
        }
        public void StudentsByAccreditation()
        {
            if (AccreditationGrade == 'A' || AccreditationGrade == 'a')
            {
                StudentsCount = (int)(StudentsCount * 1.2);
                Console.WriteLine("\nОцінка A: кількість студентів збільшено на 20%.");
            }
            else if (AccreditationGrade == 'B' || AccreditationGrade == 'b')
            {
                Console.WriteLine("\nОцінка B: кількість студентів залишається без змін.");
            }
            else if (AccreditationGrade == 'E' || AccreditationGrade == 'e')
            {
                StudentsCount = (int)(StudentsCount * 0.9);
                Console.WriteLine("\nОцінка E: кількість студентів зменшено на 10%.");
            }
            else
            {
                Console.WriteLine("Невідома оцінка акредитації.");
            }
        }
    }
}