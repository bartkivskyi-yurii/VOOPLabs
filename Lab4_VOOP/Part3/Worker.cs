using System;
using System.Collections.Generic;
using System.Text;

namespace Bartkivskyi_Lab4_VOOP_Part3
{
    internal class Worker : Human
    {
        private string workAchievements;
        private string professionalSkills;
        private string personalQualities;
        public Worker(string firstName, string position, int age, int workExpirience, int salary, string workAchievements, string professionalSkills, string personalQualities) : base(firstName, position, age, workExpirience, salary)
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
        public void EngineDevelopment(Engineer engineer)
        {
            bool understandable = engineer.DesignEngine();

            if (understandable == true)
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
    }
}