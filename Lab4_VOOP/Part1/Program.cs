using System;
using System.Text;

namespace Bartkivskyi_Lab4_VOOP
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("===== Engineer =====\n");
            Engineer eng = new Engineer("Артур", "Головний інженер-конструктор", 27, 6, 50000, "Створення екологічного двигуна з нульовим рівнем викидів", "досвід проєктування ДВЗ (двигунів внутрішнього згоряння), робота з 3D-моделюванням", "Відповідальність, прямолінійність, цілеспрямованість");
            eng.PrintInfo();

            Console.WriteLine("===== Worker =====\n");
            Worker work = new Worker("Максим", "Старший майстер виробничого цеху", 31, 13, 40000, "звання 'Золоті руки заводу' та нуль відсотків браку за останні 3 роки", "вільне читання найскладніших технічних креслень та схем", "Залізна витримка, стресостійкість, педантичність");
            work.PrintInfo();

            Console.WriteLine("===== Спільна робота =====\n");
            work.EngineDevelopment(eng);
        }
    }
}