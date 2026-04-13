using System;
using System.Collections.Generic;
using System.Text;

namespace Bartkivskyi_Lab4_VOOP
{
    internal class Engineer : Human
    {
        private string workAchievements;
        private string professionalSkills;
        private string personalQualities;
        public Engineer(string firstName, string position, int age, int workExpirience, int salary, string workAchievements, string professionalSkills, string personalQualities) : base(firstName, position, age, workExpirience, salary)
        {
            this.workAchievements = workAchievements;
            this.professionalSkills = professionalSkills;
            this.personalQualities = personalQualities;
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
    }
}