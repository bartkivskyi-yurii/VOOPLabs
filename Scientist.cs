using System;
using System.Collections.Generic;
using System.Text;

namespace Barrtkivskyi_Lab5_VOOP
{
    internal class Scientist : Human
    {
        private string fieldOfStudy;
        private string academicDegree;
        private int publicationsCount;
        private int currentWorkVolume;
        public Scientist()
        {
            fieldOfStudy = "";
            academicDegree = "";
            publicationsCount = 0;
        }
        public Scientist(string firstName) : base(firstName)
        {
        }
        public Scientist(string firstName, string position) : base(firstName, position)
        {
        }
        public Scientist(string firstName, string position, int age) : base(firstName, position, age)
        {
        }
        public Scientist(string firstName, string position, int age, int workExpirience) : base(firstName, position, age, workExpirience)
        {
        }
        public Scientist(string firstName, string position, int age, int workExpirience, int salary) : base(firstName, position, age, workExpirience, salary)
        {
        }
        public Scientist(string firstName, string position, int age, int workExpirience, int salary, string fieldOfStudy) : base(firstName, position, age, workExpirience, salary)
        {
            this.fieldOfStudy = fieldOfStudy;
        }
        public Scientist(string firstName, string position, int age, int workExpirience, int salary, string fieldOfStudy, string academicDegree) : base(firstName, position, age, workExpirience, salary)
        {
            this.fieldOfStudy = fieldOfStudy;
            this.academicDegree = academicDegree;
        }
        public Scientist(string firstName, string position, int age, int workExpirience, int salary, string fieldOfStudy, string academicDegree, int publicationsCount, int currentWorkVolume) : base(firstName, position, age, workExpirience, salary)
        {
            this.fieldOfStudy = fieldOfStudy;
            this.academicDegree = academicDegree;
            this.publicationsCount = publicationsCount;
            this.currentWorkVolume = currentWorkVolume;
        }
        public string FieldOfStudy
        {
            get { return fieldOfStudy; }
            set { fieldOfStudy = value; }
        }
        public string AcademicDegree
        {
            get { return academicDegree; }
            set {  academicDegree = value; }
        }
        public int PublicationsCount
        {
            get { return publicationsCount; }
            set {  publicationsCount = value; }
        }
        public int CurrentWorkVolume
        {
            get { return currentWorkVolume; }
            set { currentWorkVolume = value; }
        }
        public override void PrintInfo()
        {
            base.PrintInfo();

            Console.WriteLine($"Сфера навчання: {FieldOfStudy}");
            Console.WriteLine($"Вчений ступінь: {AcademicDegree}");
            Console.WriteLine($"Уількість виставлених робіт: {PublicationsCount}\n");
        }
        public override void WorkProgress()
        {
            Console.WriteLine($"Науковець {FirstName} захистив патент на винахід.");
        }
        public override void WorkProgress(int patentCount)
        {
            int standardGrant = 15000;
            int earned = patentCount * standardGrant;
            this.Salary += earned;
            Console.WriteLine($"Науковець {FirstName} отримав {patentCount} патентів. Стандартний грант: {earned}");
        }
        public override void WorkProgress(int patentCount, int customGrant)
        {
            int earned = (patentCount * customGrant) * 100;
            this.Salary += earned;
            Console.WriteLine($"Науковець {FirstName} отримав {patentCount} міжнародних патентів. Великий грант: {earned}\n");
        }
        public override void CalculateIQ()
        {
            IQ = 125;
            Console.WriteLine($"Науковець {FirstName}: Базовий рівень IQ = {IQ}");
        }
        public override void CalculateIQ(int heredity, int health)
        {
            IQ = 95 + (heredity * 3) + health;
            Console.WriteLine($"Науковець {FirstName}: IQ (біологія) = {IQ}");
        }
        public override void CalculateIQ(int heredity, int familyInfluence, int environment, int familyIncome, int economy, int health)
        {
            IQ = 85 + (heredity * 2) + (familyInfluence * 2) + (environment * 3) + familyIncome + economy + health;
            Console.WriteLine($"Науковець {FirstName}: IQ (повний розрахунок) = {IQ}");
        }
        public static bool operator ==(Scientist s1, Scientist s2)
        {
            if (ReferenceEquals(s1, null) || ReferenceEquals(s2, null))
            {
                return ReferenceEquals(s1, s2);
            }
            return s1.Salary == s2.Salary;
        }
        public static bool operator !=(Scientist s1, Scientist s2)
        {
            return !(s1 == s2);
        }
        public static Scientist operator -(Scientist scientist)
        {
            scientist.Salary = -scientist.Salary;
            Console.WriteLine($"У науковця {scientist.FirstName} змінено баланс. Поточний стан: {scientist.Salary}");
            return scientist;
        }
    }
}