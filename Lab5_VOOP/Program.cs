using System;
using System.Text;

namespace Barrtkivskyi_Lab5_VOOP
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Engineer\n");
            Engineer eng1 = new Engineer("Артур", "Головний інженер-конструктор", 35, 10, 45000);
            Engineer eng2 = new Engineer("Володя", "Інженер-конструктор", 20, 2, 25000);
            eng1.PrintInfo();
            eng2.PrintInfo();

            Console.WriteLine("Worker\n");
            Worker work1 = new Worker("Максим", "Старший майстер виробничого цеху", 31, 13, 30000, "звання 'Золоті руки заводу' та нуль відсотків браку за останні 3 роки", "вільне читання найскладніших технічних креслень та схем", "Залізна витримка, стресостійкість, педантичність", 3);
            Worker work2 = new Worker("Анна", "Майстер виробничого цеху", 19);
            work1.PrintInfo();
            work2.PrintInfo();

            Console.WriteLine("Спільна робота\n");
            work1.EngineDevelopment(eng1);

            Console.WriteLine("Scientist");
            Scientist scientist1 = new Scientist("Вадим", "Головний науковець", 50, 27, 35000);
            Scientist scientist2 = new Scientist("Оксана", "Науковиця", 40, 15, 32000);
            scientist1.PrintInfo();
            scientist2.PrintInfo();

            work1.WorkProgress();
            eng1.WorkProgress(8);
            scientist1.WorkProgress(10, 7);

            work1.CalculateIQ();
            work2.CalculateIQ(10, 10);
            eng1.CalculateIQ(9, 7);
            scientist1.CalculateIQ(10, 10, 10, 10, 10, 10);

            if (work1 > work2)
            {
                Console.WriteLine($"{work1.FirstName} має вищий рівень інтелекту ніж {work1.FirstName}\n");
            }
            else if (work1 < work2)
            {
                Console.WriteLine($"{work1.FirstName} має менший рівень інтелекту ніж {work2.FirstName}\n");
            }

            eng1 = eng1 - 1;
            Console.WriteLine($"Зарплата {eng1.FirstName} після (-1 обсяги робіт): {eng1.Salary}\n");

            eng2 = eng2 + 2;
            Console.WriteLine($"Зарплата {eng2.FirstName} після (+2 обсяги робіт): {eng2.Salary}\n");

            if (scientist1 == scientist2)
            {
                Console.WriteLine($"Заробітня плата {scientist1.FirstName} дорівнює заробітній платі {scientist2.FirstName}\n");
            }
            else if (scientist1 != scientist2)
            {
                Console.WriteLine($"Заробітня плата {scientist1.FirstName} не дорівнює заробітній платі {scientist2.FirstName}\n");
            }
            work1--;
            for (int i = 0; i < 2; i++)
            {
                eng1++;
            }
            scientist1 = -scientist1;

            ScientistsTeam team = new ScientistsTeam(3);

            team[0] = new Scientist { FirstName = "Олег", Salary = 15000, CurrentWorkVolume = 5 };
            team[1] = new Scientist { FirstName = "Дарина", Salary = 18000, CurrentWorkVolume = 7 };
            team[2] = new Scientist { FirstName = "Ігор", Salary = 14000, CurrentWorkVolume = 4 };

            Console.WriteLine("\nСписок команди:");

            for (int i = 0; i < team.Length; i++)
            {
                Console.WriteLine($"Індекс [{i}]: Ім'я: {team[i].FirstName}, Зарплата: {team[i].Salary}, Проекти: {team[i].CurrentWorkVolume}");
            }

            Console.WriteLine("\nДоступ до конкретного об'єкта:");
            Console.WriteLine($"Дамо премію робітнику під індексом [1] ({team[1].FirstName}).");

            team[1].Salary += 5000;

            Console.WriteLine($"Нова зарплата {team[1].FirstName}: {team[1].Salary}");
        }
    }
}