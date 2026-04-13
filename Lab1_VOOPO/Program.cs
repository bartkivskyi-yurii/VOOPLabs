using System;

namespace Console_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Символи "і", "ї", "є" у консолі
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Варіант 14");
            Console.WriteLine("1 - Анкетні дані та ромб");
            Console.WriteLine("2 - Обчислення виразу");
            Console.WriteLine("3 - Обчислення функції f(x)");
            Console.WriteLine("4 - Колір спектра (RGB)");
            Console.WriteLine("5 - Сума ряду");
            Console.Write("Оберіть завдання: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
                case 5:
                    Task5();
                    break;
                default:
                    Console.WriteLine("Невірний вибір");
                    break;
            }

            Console.ReadLine();
        }

        // ===== Завдання 1 =====
        static void Task1()
        {
            Console.WriteLine("\nАнкетні дані:");
            Console.WriteLine("Бартківський Юрій, 17 років, гр. ІПЗ-11(2), 1 курс, bartkivskyi.yu@knu.ua");

            Console.Write("\nВведіть значення висоти: ");
            double h = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть значення периметра: ");
            double P = Convert.ToDouble(Console.ReadLine());
            
            double a = P / 8.0; // Знаходження половини сторони ромба

            double d = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(h, 2)); // Знаходження меншої діагоналі ромба

            Console.WriteLine($"Менша діагональ ромба = {d}");
        }

        // ===== Завдання 2 =====
        static void Task2()
        {
            Console.Write("Введіть a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть b: ");
            double b = Convert.ToDouble(Console.ReadLine());

            double c = 2 + b;

            if (b == 0 || b == -1)
            {
                Console.WriteLine("Ділення на 0");
                return;
            }

            else if (c <= 0)
            {
                Console.WriteLine("Число логарифма <= 0.");
                return;
            }

            else
            {
                double x = Math.Exp(a) * Math.Sqrt(Math.Sin(a * a) / Math.Log(c)) + Math.Tan(a / b);

                Console.WriteLine($"x = {x}");
            }
        }

        // ===== Завдання 3 =====
        static void Task3()
        {
            Console.Write("Введіть a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть x: ");
            double x = Convert.ToDouble(Console.ReadLine());

            double fx;

            if (x < 1 && x >= -1 && a > 0)
                fx = -a * x;
            else if (x > 1 && a < 0)
                fx = a - x;
            else if (x == 1 && a == 0)
                fx = a / x;
            else
            {
                Console.WriteLine("Умова не виконується");
                return;
            }

            Console.WriteLine($"f(x) = {fx}");
        }

        // ===== Завдання 4 =====
        static void Task4()
        {
            Console.Write("Введіть назву кольору: ");
            string color = Console.ReadLine().ToLower();

            switch (color)
            {
                case "червоний":
                    Console.WriteLine("RGB(255, 0, 0)");
                    break;
                case "помаранчевий":
                    Console.WriteLine("RGB(255, 165, 0)");
                    break;
                case "жовтий":
                    Console.WriteLine("RGB(255, 255, 0)");
                    break;
                case "зелений":
                    Console.WriteLine("RGB(0, 255, 0)");
                    break;
                case "блакитний":
                    Console.WriteLine("RGB(0, 255, 255)");
                    break;
                case "синій":
                    Console.WriteLine("RGB(0, 0, 255)");
                    break;
                case "фіолетовий":
                    Console.WriteLine("RGB(128, 0, 128)");
                    break;
                default:
                    Console.WriteLine("Невідомий колір");
                    break;
            }
        }

        // ===== Завдання 5 =====
        static void Task5()
        {
            Console.Write("Введіть n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введіть x > 0: ");
            double x = Convert.ToDouble(Console.ReadLine());

            double S = 0; // Сума

            for (int i = 1; i <= n; i++)
            {
                S += (Math.Pow(-1, i) * Math.Pow(x, i)) / ((i + 1) * (1 + Math.Pow(x, i)));
            }

            Console.WriteLine($"S = {S}");
        }
    }
}