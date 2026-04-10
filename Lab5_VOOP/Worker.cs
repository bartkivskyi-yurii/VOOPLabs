using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Barrtkivskyi_Lab5_VOOP
{
    internal class Worker : Human
    {
        private string workAchievements;
        private string professionalSkills;
        private string personalQualities;
        private int currentWorkVolume;
        public Worker()
        {
            workAchievements = "";
            professionalSkills = "";
            personalQualities = "";
            currentWorkVolume = 0;
        }
        public Worker(string firstName) : base(firstName)
        {
        }
        public Worker(string firstName, string position) : base(firstName, position)
        {
        }
        public Worker(string firstName, string position, int age) : base(firstName, position, age)
        {
        }
        public Worker(string firstName, string position, int age, int workExpirience) : base(firstName, position, age, workExpirience)
        {
        }
        public Worker(string firstName, string position, int age, int workExpirience, int salary) : base(firstName, position, age, workExpirience, salary)
        {
        }
        public Worker(string firstName, string position, int age, int workExpirience, int salary, string workAchievements) : base(firstName, position, age, workExpirience, salary)
        {
            this.workAchievements = workAchievements;
        }
        public Worker(string firstName, string position, int age, int workExpirience, int salary, string workAchievements, string professionalSkills) : base(firstName, position, age, workExpirience, salary)
        {
            this.workAchievements = workAchievements;
            this.professionalSkills = professionalSkills;
        }
        public Worker(string firstName, string position, int age, int workExpirience, int salary, string workAchievements, string professionalSkills, string personalQualities, int currentWorkVolume) : base(firstName, position, age, workExpirience, salary)
        {
            this.workAchievements = workAchievements;
            this.professionalSkills = professionalSkills;
            this.personalQualities = personalQualities;
            this.currentWorkVolume = currentWorkVolume;
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
        public void EngineDevelopment(Engineer engineer)
        {
            bool understandable = engineer.DesignEngine();

            if (understandable)
            {
                Console.WriteLine($"Робітник {FirstName} отримав креслення від інженера, після дослідження цілком зрозумілого креслення, робітник приступив до розробки.");

                if (WorkExperience >= 10)
                {
                    Console.WriteLine($"Завдяки досвіду роботи в {WorkExperience} років, професійним навичкам: {ProfessionalSkills} і його особистим якостям, таким як: {PersonalQualities}, розробка пішля як по маслу.\n");
                }
                else
                {
                    Console.WriteLine($"Хоч досвід роботи в робітника лише {WorkExperience} років, завдяки його особистості {PersonalQualities} і зрозумілому поясненю, він зміг виконати роботу, хоч із невеличкими труднощами.\n");
                }
            }
            else
            {
                Console.WriteLine($"Робітник {FirstName} отримав креслення від інженера, але йому знадобилося більше часу на розбір креслення через невеликий досвід інженера.");

                if (WorkExperience >= 10)
                {
                    Console.WriteLine($"Завдяки досвіду роботи в {WorkExperience} років, професійним навичкам: {ProfessionalSkills}, попри недосконале креслення працівник впрорався із завданням.\n");
                }
                else
                {
                    Console.WriteLine($"Досвід роботи в робітника лише {WorkExperience} років, попри недосконале креслення, він зміг виконати роботу, з великими труднощами.\n");
                }
            }
        }
        public override void WorkProgress()
        {
            Console.WriteLine($"Робітник {FirstName} налагодив обладнання.");
        }
        public override void WorkProgress(int machineCount)
        {
            int standardRate = 500;
            int earned = machineCount * standardRate;
            this.Salary += earned;
            Console.WriteLine($"Робітник {FirstName} налагодив {machineCount} од. обладнання. Стандартна плата: {earned}");
        }
        public override void WorkProgress(int machineCount, int customRate)
        {
            int earned = machineCount * customRate;
            this.Salary += earned;
            Console.WriteLine($"Робітник {FirstName} налагодив {machineCount} од. обладнання за особливим тарифом. Оплата: {earned}");
        }
        public override void CalculateIQ()
        {
            IQ = 95;
            Console.WriteLine($"Робітник {FirstName}: Базовий рівень IQ = {IQ}");
        }
        public override void CalculateIQ(int heredity, int health)
        {
            IQ = 80 + heredity + (health * 2);
            Console.WriteLine($"Робітник {FirstName}: IQ (біологія) = {IQ}");
        }
        public override void CalculateIQ(int heredity, int familyInfluence, int environment, int familyIncome, int economy, int health)
        {
            IQ = 75 + heredity + familyInfluence + (environment * 2) + familyIncome + economy + (health * 2);
            Console.WriteLine($"Робітник {FirstName}: IQ (повний розрахунок) = {IQ}");
        }
        public static bool operator >(Worker w1, Worker w2)
        {
            return w1.IQ > w2.IQ;
        }
        public static bool operator <(Worker w1, Worker w2)
        {
            return w1.IQ < w2.IQ;
        }
        public static Worker operator --(Worker work)
        {
            work.CurrentWorkVolume -= 1;

            if (work.CurrentWorkVolume < 0)
            {
                work.CurrentWorkVolume = 0;
            }

            Console.WriteLine($"Обсяг робіт інженера {work.FirstName} зменшено. Поточні проекти: {work.CurrentWorkVolume}\n");
            return work;
        }
    }
}