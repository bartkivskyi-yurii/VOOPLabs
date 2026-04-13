using System;
using System.Text;

namespace Bartkivskyi_Lab4_VOOP_Part4
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Worker[] factoryWorkers = new Worker[]
            {
            new Worker("Іван", "Токар", 22, 10, 25000, "Відсутні", "Відсутні", "Відсутні"),
            new Worker("Олег", "Слюсар", 35, 2, 18000, "Відсутні", "Відсутні", "Відсутні"),
            new Worker("Максим", "Зварювальник", 40, 15, 25000, "Відсутні", "Відсутні", "Відсутні")
            };
            
            Array.Sort(factoryWorkers);
            foreach (Worker w in factoryWorkers)
            {
                Console.WriteLine($"{w.FirstName} - Вік: {w.Age}");
            }

            Array.Sort(factoryWorkers, new AgeAndSalaryComparer());
            foreach (var w in factoryWorkers)
            {
                Console.WriteLine($"{w.FirstName} Вік: {w.Age} | ЗП: {w.Salary}");
            }
        }
    }
}