using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Barrtkivskyi_Lab5_VOOP
{
    internal class Human
    {
        private string firstName;
        private string position;
        private int age;
        private int workExperience;
        private int salary;
        private int iq;
        public Human()
        {
            firstName = "";
            position = "";
            age = 0;
            workExperience = 0;
            salary = 0;
        }
        public Human(string firstName)
        {
            this.firstName = firstName;
        }
        public Human(string firstName, string position)
        {
            this.firstName = firstName;
            this.position = position;
        }
        public Human(string firstName, string position, int age)
        {
            this.firstName = firstName;
            this.position = position;
            this.age = age;
        }
        public Human(string firstName, string position, int age, int workExpirience)
        {
            this.firstName = firstName;
            this.position = position;
            this.age = age;
            this.workExperience = workExpirience;
        }
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
        public int IQ { get; protected set; }
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Ім'я: {FirstName}");
            Console.WriteLine($"Посада: {Position}");
            Console.WriteLine($"Вік: {Age}");
            Console.WriteLine($"Досвід роботи (роки): {WorkExperience}");
            Console.WriteLine($"Зарплата (грн): {Salary}");
        }
        public virtual void WorkProgress()
        {
            Console.WriteLine($"{firstName} виконує загальну роботу.");
        }
        public virtual void WorkProgress(int volume)
        {
            int standardRate = 100;
            int earned = volume * standardRate;
            this.salary += earned;
            Console.WriteLine($"{firstName} виконав роботу обсягом {volume}. Стандартна оплата: {earned}");
        }
        public virtual void WorkProgress(int volume, int customRate)
        {
            int earned = volume * customRate;
            this.salary += earned;
            Console.WriteLine($"{firstName} виконав роботу обсягом {volume}. Спеціальна оплата: {earned}");
        }
        public virtual void CalculateIQ() { }
        public virtual void CalculateIQ(int heredity, int health)
        {
            iq = 80 + (heredity * 2) + health;
            Console.WriteLine($"{firstName}: IQ за біологічними факторами = {iq}");
        }
        public virtual void CalculateIQ(int heredity, int familyInfluence, int environment, int familyIncome, int economy, int health)
        {
            iq = 70 + heredity + familyInfluence + environment + familyIncome + economy + health;
            Console.WriteLine($"{firstName}: IQ за всіма факторами (загальний) = {iq}");
        }
    }
}