using System;
using System.Collections.Generic;
using System.Text;

namespace Barrtkivskyi_Lab5_VOOP
{
    internal class Engineer : Human
    {
        private string workAchievements;
        private string professionalSkills;
        private string personalQualities;
        private int currentWorkVolume;
        public Engineer()
        {
            workAchievements = "";
            professionalSkills = "";
            personalQualities = "";
            currentWorkVolume = 0;
        }
        public Engineer(string firstName) : base(firstName)
        {
        }
        public Engineer(string firstName, string position) : base(firstName, position)
        {
        }
        public Engineer(string firstName, string position, int age) : base(firstName, position, age)
        {
        }
        public Engineer(string firstName, string position, int age, int workExpirience) : base(firstName, position, age, workExpirience)
        {
        }
        public Engineer(string firstName, string position, int age, int workExpirience, int salary) : base(firstName, position, age, workExpirience, salary)
        {
        }
        public Engineer(string firstName, string position, int age, int workExpirience, int salary, string workAchievements) : base(firstName, position, age, workExpirience, salary)
        {
            this.workAchievements = workAchievements;
        }
        public Engineer(string firstName, string position, int age, int workExpirience, int salary, string workAchievements, string professionalSkills) : base(firstName, position, age, workExpirience, salary)
        {
            this.workAchievements = workAchievements;
            this.professionalSkills = professionalSkills;
        }
        public Engineer(string firstName, string position, int age, int workExpirience, int salary, string workAchievements, string professionalSkills, string personalQualities, int currentWorkVolume) : base(firstName, position, age, workExpirience, salary)
        {
            this.workAchievements = workAchievements;
            this.professionalSkills = professionalSkills;
            this.personalQualities = personalQualities;
            this.currentWorkVolume = currentWorkVolume;
        }
        public Engineer(Engineer other) : base(other.FirstName, other.Position, other.Age, other.WorkExperience, other.Salary)
        {
            this.workAchievements = other.workAchievements;
            this.professionalSkills = other.professionalSkills;
            this.personalQualities = other.personalQualities;
        }
        public string WorkAchievements
        {
            get { return workAchievements; }
            set { workAchievements = value; }
        }
        public string ProfessionalSkills
        {
            get { return professionalSkills; }
            set { professionalSkills = value; }
        }
        public string PersonalQualities
        {
            get { return personalQualities; }
            set { personalQualities = value; }
        }
        public int CurrentWorkVolume
        {
            get { return currentWorkVolume; }
            set { currentWorkVolume = value; }
        }
        public override void PrintInfo()
        {
            base.PrintInfo();

            Console.WriteLine($"Трудові досягнення: {WorkAchievements}");
            Console.WriteLine($"Професійні навички: {ProfessionalSkills}");
            Console.WriteLine($"Особисті якості: {PersonalQualities}\n");
        }
        public bool DesignEngine()
        {
            if (WorkExperience >= 5)
            {
                Console.WriteLine($"Інженер {FirstName} маючи за плечима такі вагомі здобутки як: {WorkAchievements}, вирішив створити абсолютно новий, революційний двигун.");
                Console.WriteLine($"Оскільки його досвід роботи становить понад 5 років, він чудово знає всі технічні нюанси. Розробка проходить доволі швидко, без жодних затримок\n");
                return true;
            }
            else
            {
                Console.WriteLine("Хоча його досвід роботи ще не такий великий, інженер старанно вивчає довідники і впевнено просувається вперед у створенні двигуна.\n");
                return false;
            }
        }
        public override void WorkProgress()
        {
            Console.WriteLine($"Інженер {FirstName} здав замовнику проект.");
        }
        public override void WorkProgress(int projectCount)
        {
            int standardBonus = 5000;
            int earned = projectCount * standardBonus;
            this.Salary += earned;
            Console.WriteLine($"Інженер {FirstName} розробив {projectCount} проектів. Стандартна премія: {earned}");
        }
        public override void WorkProgress(int projectCount, int customBonus)
        {
            int earned = projectCount * customBonus;
            this.Salary += earned;
            Console.WriteLine($"Інженер {FirstName} розробив {projectCount} VIP-проектів. Спеціальна премія: {earned}");
        }
        public override void CalculateIQ()
        {
            IQ = 110;
            Console.WriteLine($"Інженер {FirstName}: Базовий рівень IQ = {IQ}");
        }
        public override void CalculateIQ(int heredity, int health)
        {
            IQ = 90 + (heredity * 2) + health;
            Console.WriteLine($"Інженер {FirstName}: IQ (біологія) = {IQ}");
        }
        public override void CalculateIQ(int heredity, int familyInfluence, int environment, int familyIncome, int economy, int health)
        {
            IQ = 80 + heredity + familyInfluence + (environment * 2) + familyIncome + (economy * 3) + health;
            Console.WriteLine($"Інженер {FirstName}: IQ (повний розрахунок) = {IQ}");
        }
        public static Engineer operator +(Engineer eng, int extraWorkVolume)
        {
            int ratePerVolume = 2000;
            eng.Salary += extraWorkVolume * ratePerVolume;
            return eng;
        }
        public static Engineer operator -(Engineer eng, int canceledWorkVolume)
        {
            int ratePerVolume = 2000;

            eng.Salary -= Math.Abs(canceledWorkVolume) * ratePerVolume;

            if (eng.Salary < 0)
            {
                eng.Salary = 0;
            }

            return eng;
        }
        public static Engineer operator ++(Engineer eng)
        {
            eng.CurrentWorkVolume += 1;
            Console.WriteLine($"Обсяг робіт інженера {eng.FirstName} збільшено. Поточні проекти: {eng.CurrentWorkVolume}\n");
            return eng;
        }
    }
}