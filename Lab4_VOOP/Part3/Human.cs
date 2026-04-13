using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Bartkivskyi_Lab4_VOOP_Part3
{
    internal class Human : LivingBeing
    {
        private string firstName;
        private string position;
        private int age;
        private int workExperience;
        private int salary;
        public Human(string firstName, string position, int age, int workExpirience, int salary)
        {
            this.firstName = firstName;
            this.position = position;
            this.age = age;
            this.workExperience = workExpirience;
            this.salary = salary;
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public int WorkExperience
        {
            get { return workExperience; }
            set { workExperience = value; }
        }
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Ім'я: {FirstName}");
            Console.WriteLine($"Посада: {Position}");
            Console.WriteLine($"Вік: {Age}");
            Console.WriteLine($"Досвід роботи: {WorkExperience}");
            Console.WriteLine($"Зарплата (грн): {Salary}");
        }
        public override void Think()
        {
            Console.WriteLine($"{FirstName} Думає як виконати завдання");
        }
    }
}