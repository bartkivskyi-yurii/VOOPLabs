using System;
using System.Text;

namespace Bartkivskyi_Lab4_VOOP_Part2
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("===== Завдання 7 =====\n");
            Interface interfaceEng = new Engineer("Артур", "Головний інженер-конструктор", 27, 6, 50000, "Створення екологічного двигуна з нульовим рівнем викидів", "досвід проєктування ДВЗ (двигунів внутрішнього згоряння), робота з 3D-моделюванням", "Відповідальність, прямолінійність, цілеспрямованість");
            Interface interfaceWork = new Worker("Максим", "Старший майстер виробничого цеху", 31, 13, 40000, "звання 'Золоті руки заводу' та нуль відсотків браку за останні 3 роки", "вільне читання найскладніших технічних креслень та схем", "Залізна витримка, стресостійкість, педантичність");

            interfaceEng.DoWork();
            interfaceWork.DoWork();
        }
    }
}