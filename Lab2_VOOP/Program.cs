using System;

namespace Console_Lab2
{
    public static class Program
    {
        private static int[] arr;
        private static int size;
        private static int min;
        private static int max;
        private static int[,] matrix;
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Варіант 4");

            int choice;
            do
            {
                Console.WriteLine("\n=============== МЕНЮ ===============");
                Console.WriteLine("1 - Згенерувати та сортувати масив");
                Console.WriteLine("2 - алгоритм Ератосфена");
                Console.WriteLine("3 - Переформувати масив");
                Console.WriteLine("4 - Знайти максимальне число серед від'ємних і\nмінімальне серед додатніх");
                Console.WriteLine("5 - Бінарний пошук");
                Console.WriteLine("6 - Матриця");
                Console.WriteLine("7 - Мінімальні та максимальні значення матриці");
                Console.WriteLine("8 - Розв'язання нелінійного рівняння методом бісекції");
                Console.WriteLine("9 - Перевірка дужок");
                Console.WriteLine("0 - Вихід");

                try
                {
                    choice = Convert.ToByte(Console.ReadLine());
                }
                catch
                {
                    choice = 255;
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nУведіть кількість елементів масиву: ");
                        size = int.Parse(Console.ReadLine());
                        Console.WriteLine("Уведіть мінімальне число діапазону: ");
                        min = int.Parse(Console.ReadLine());
                        Console.WriteLine("Уведіть максимальне число діапазону: ");
                        max = int.Parse(Console.ReadLine());

                        if (min > max)
                        {
                            int temp = min;
                            min = max;
                            max = temp;
                            Console.WriteLine("Межі змінено місцями автоматично.");
                        }
                        Program.GenerateArr(size, min, max);
                        Program.InsertionSort(size, arr);
                        break;
                    case 2:
                        Program.FindPrimes();
                        break;
                    case 3:
                        Program.RearrangeArray();
                        break;
                    case 4:
                        Program.FoundMinMax();
                        break;
                    case 5:
                        Program.FindMultiplesUsingBinarySearch();
                        break;
                    case 6:
                        Program.GenerateAndAnalyzeMatrix();
                        break;
                    case 7:
                        Program.FindMatrixMinMax();
                        break;
                    case 8:
                        Program.SolveNonLinearEquation();
                        break;
                    case 9:
                        Program.CheckBrackets();
                        break;
                    default:
                        Console.WriteLine("Будь ласка, обирайте варіант із зазначених");
                        break;
                }
            } while (choice != 0);
        }
        private static void GenerateArr(int n, int min, int max)
        {
            Random rand = new Random();
            arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = rand.Next(min, max + 1);
            Console.WriteLine("\nЗгенеровано масив: " + string.Join(", ", arr) + '\n');
        }
        private static void InsertionSort(int n, int[] arr)
        {
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    int temp = arr[j + 1];
                    arr[j + 1] = arr[j];
                    arr[j] = temp;

                    j -= 1;
                }
                Console.WriteLine($"Крок сортування №{i}: " + string.Join(", ", arr));
            }
            Console.WriteLine("\nВідсортований масив: " + string.Join(", ", arr));
        }
        private static void FindPrimes()
        {
            // Перевірка на порожній масив
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Масив не створено. Спочатку згенеруйте масив (пункт 1).");
                return;
            }

            // Шукаємо максимальне число в масиві, щоб визначити розмір Решета
            int maxVal = 0;
            foreach (int num in arr)
            {
                if (num > maxVal) maxVal = num;
            }

            // Якщо в масиві немає чисел більше 1, то простих чисел там точно немає
            if (maxVal < 2)
            {
                Console.WriteLine("У масиві відсутні прості числа.");
                return;
            }

            // Створюємо Решето Ератосфена
            // Індекс масиву відповідає числу. isPrime[5] - чи просте число 5.
            bool[] isPrime = new bool[maxVal + 1];

            // Спочатку вважаємо всі числа від 2 до maxVal простими
            for (int i = 2; i <= maxVal; i++)
            {
                isPrime[i] = true;
            }

            // Основний алгоритм Ератосфена
            for (int p = 2; p * p <= maxVal; p++)
            {
                // Якщо p не викреслене, то це просте число
                if (isPrime[p])
                {
                    // Викреслюємо всі кратні числа, починаючи з p*p
                    for (int i = p * p; i <= maxVal; i += p)
                    {
                        isPrime[i] = false;
                    }
                }
            }

            // Вибираємо прості числа з нашого початкового масиву
            string result = "";
            int count = 0;

            foreach (int num in arr)
            {
                // Перевіряємо: число має бути додатним і позначеним як true у решеті
                if (num > 1 && isPrime[num])
                {
                    result += num + " ";
                    count++;
                }
            }

            // Виведення результату
            if (count > 0)
            {
                Console.WriteLine("Прості числа у масиві: " + result);
            }
            else
            {
                Console.WriteLine("У згенерованому масиві відсутні прості числа.");
            }
        }
        private static void RearrangeArray()
        {
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Масив порожній.");
                return;
            }

            int positionToInsert = 0; // Індекс, куди будемо вставляти не-нульові числа

            for (int i = 0; i < arr.Length; i++)
            {
                // Якщо число не нуль — пересуваємо його вліво на позицію positionToInsert
                if (arr[i] != 0)
                {
                    arr[positionToInsert] = arr[i];
                    positionToInsert++;
                }
            }

            // Всі комірки, що залишилися після останнього вставленого числа, заповнюємо нулями
            while (positionToInsert < arr.Length)
            {
                arr[positionToInsert] = 0;
                positionToInsert++;
            }

            Console.WriteLine("\nМасив переформовано (нулі в кінці): " + string.Join(", ", arr));
        }
        private static void FoundMinMax()
        {
            int maxNeg = int.MinValue;
            int maxNegIndex = 0;
            bool foundNeg = false;  //Чи є від'ємні

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    if (!foundNeg || arr[i] > maxNeg)
                    {
                        maxNeg = arr[i];
                        maxNegIndex = i;
                        foundNeg = true;
                    }
                }
            }

            if (foundNeg)
                Console.WriteLine($"\nМаксимальне від'ємне: {maxNeg} (індекс {maxNegIndex})");
            else
                Console.WriteLine("Від'ємні числа відсутні.");

            int minPos = int.MaxValue;
            int minPosIndex = 0;
            bool foundPos = false;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    if (!foundPos || arr[i] < minPos)
                    {
                        minPos = arr[i];
                        minPosIndex = i;
                        foundPos = true;
                    }
                }
            }

            if (foundPos)
                Console.WriteLine($"Мінімальне додатне: {minPos} (індекс {minPosIndex})");
            else
                Console.WriteLine("Додатні числа відсутні.");
        }
        private static void FindMultiplesUsingBinarySearch()
        {
            // 1. Перевірка на порожній масив
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Масив порожній. Спочатку згенеруйте його.");
                return;
            }

            Console.Write("Введіть число K для пошуку кратних елементів: ");
            int k;
            if (!int.TryParse(Console.ReadLine(), out k) || k == 0)
            {
                Console.WriteLine("Помилка: введіть ціле число, що не дорівнює нулю.");
                return;
            }

            // Для зручності беремо модуль числа K (щоб крок був додатнім)
            int step = Math.Abs(k);

            // Визначаємо межі масиву
            int minVal = arr[0];
            int maxVal = arr[arr.Length - 1];

            Console.WriteLine($"\nШукаємо числа, кратні {k}, в діапазоні значень масиву...");

            // Знаходимо перше число в діапазоні, яке ділиться на step
            // Наприклад, якщо діапазон [-10, 10] і k=3, старт буде з -9
            int currentSearchValue = minVal - (minVal % step);
            if (minVal > 0 && minVal % step != 0) currentSearchValue += step;

            // Коригування старту, щоб ми не починали пошук лівіше за мінімальне число
            if (currentSearchValue < minVal) currentSearchValue += step;

            int totalCount = 0;
            string foundValues = "";

            // === ГОЛОВНИЙ ЦИКЛ ПОШУКУ ===
            // Ми йдемо по числах: X, X+k, X+2k... і шукаємо кожне через BinarySearch
            while (currentSearchValue <= maxVal)
            {
                // === ВИКОРИСТАННЯ Array.BinarySearch ===
                // Повертає індекс елемента, якщо він є. Якщо немає — повертає від'ємне число.
                int index = Array.BinarySearch(arr, currentSearchValue);

                if (index >= 0)
                {
                    // Додаємо саме знайдене число
                    totalCount++;
                    foundValues += arr[index] + " ";

                    // Перевіряємо сусідів ЗЛІВА
                    int left = index - 1;
                    while (left >= 0 && arr[left] == currentSearchValue)
                    {
                        totalCount++;
                        foundValues += arr[left] + " ";
                        left--;
                    }

                    // Перевіряємо сусідів СПРАВА
                    int right = index + 1;
                    while (right < arr.Length && arr[right] == currentSearchValue)
                    {
                        totalCount++;
                        foundValues += arr[right] + " ";
                        right++;
                    }
                }

                // Переходимо до наступного кратного числа (наприклад, від 5 до 10)
                currentSearchValue += step;
            }

            // Результат
            if (totalCount > 0)
            {
                Console.WriteLine($"Знайдено {totalCount} елементів:");
                Console.WriteLine(foundValues);
            }
            else
            {
                Console.WriteLine($"Елементів, кратних {k}, не знайдено.");
            }
        }
        private static void GenerateAndAnalyzeMatrix()
        {
            // --- Введення параметрів ---
            Console.WriteLine("--- Генерація матриці прибутків ---");

            Console.Write("Введіть кількість товарів (рядки): ");
            if (!int.TryParse(Console.ReadLine(), out int rows) || rows <= 0) return;

            Console.Write("Введіть кількість місяців (стовпці): ");
            if (!int.TryParse(Console.ReadLine(), out int cols) || cols <= 0) return;

            Console.Write("Введіть мінімальний прибуток (min): ");
            int.TryParse(Console.ReadLine(), out int minVal);

            Console.Write("Введіть максимальний прибуток (max): ");
            int.TryParse(Console.ReadLine(), out int maxVal);

            // --- ВАЖЛИВА ЗМІНА ТУТ ---
            // Ми НЕ пишемо "int[,] matrix =", ми пишемо просто "matrix =",
            // щоб записати дані у змінну, яку оголосили нагорі.
            matrix = new int[rows, cols];

            long totalShopProfit = 0;
            string profitableProductsIndices = "";

            Console.WriteLine($"\n--- Таблиця прибутків ({rows} товарів x {cols} місяців) ---");

            // Друк заголовка таблиці (номери місяців)
            Console.Write("Товар \\ Міс.");
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"| {j + 1,4} ");
            }
            Console.WriteLine("|  СУМА  |");
            Console.WriteLine(new string('-', 12 + cols * 7 + 10));

            // Проходимо по рядках (Товарах)
            for (int i = 0; i < rows; i++)
            {
                long productSum = 0;

                Console.Write($"Товар #{i,-3} ");

                // Проходимо по стовпцях (Місяцях)
                for (int j = 0; j < cols; j++)
                {
                    // Використовуємо спільний rnd
                    matrix[i, j] = rnd.Next(minVal, maxVal + 1);

                    productSum += matrix[i, j];

                    Console.Write($"| {matrix[i, j],4} ");
                }

                // Аналіз конкретного товару
                totalShopProfit += productSum;

                Console.Write($"| {productSum,6} |");
                Console.WriteLine();

                if (productSum > 0)
                {
                    profitableProductsIndices += i + " ";
                }
            }
            Console.WriteLine(new string('-', 12 + cols * 7 + 10));

            // Виведення підсумків
            Console.WriteLine($"\n1. Загальний прибуток магазину: {totalShopProfit}");

            if (!string.IsNullOrEmpty(profitableProductsIndices))
            {
                Console.WriteLine($"2. Індекси товарів, які приносять прибуток: {profitableProductsIndices}");
            }
            else
            {
                Console.WriteLine("2. Прибуткових товарів немає.");
            }
        }
        private static void FindMatrixMinMax()
        {
            // 1. Перевірка на існування матриці
            // У двовимірного масиву властивість Length повертає загальну кількість елементів,
            // тому краще перевірити розмірність.
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                Console.WriteLine("Матриця порожня або не створена.");
                return;
            }

            int rows = matrix.GetLength(0); // Кількість рядків
            int cols = matrix.GetLength(1); // Кількість стовпців

            // 2. Ініціалізація початковими значеннями (перший елемент [0,0])
            int minVal = matrix[0, 0];
            int minRow = 0, minCol = 0;

            int maxVal = matrix[0, 0];
            int maxRow = 0, maxCol = 0;

            Console.WriteLine("\n--- Пошук Min/Max у матриці (з використанням Math) ---");

            // 3. Прохід по всій матриці
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int current = matrix[i, j];

                    // --- ПОШУК МАКСИМУМУ ---
                    // Використовуємо Math.Max. Якщо він повертає поточне число,
                    // значить воно більше або рівне попередньому максимуму.
                    // Щоб уникнути зайвого присвоєння, додаємо перевірку на нерівність.
                    if (current > maxVal)
                    {
                        // Тут ми формально можемо використати Math.Max, як просить завдання:
                        maxVal = Math.Max(maxVal, current);
                        maxRow = i;
                        maxCol = j;
                    }

                    // --- ПОШУК МІНІМУМУ ---
                    if (current < minVal)
                    {
                        minVal = Math.Min(minVal, current);
                        minRow = i;
                        minCol = j;
                    }
                }
            }

            // 4. Виведення результатів
            Console.WriteLine($"\nМаксимальний елемент: {maxVal}");
            Console.WriteLine($"Його індекси: [{maxRow}, {maxCol}] (Рядок {maxRow + 1}, Стовпець {maxCol + 1})");

            Console.WriteLine($"\nМінімальний елемент: {minVal}");
            Console.WriteLine($"Його індекси: [{minRow}, {minCol}] (Рядок {minRow + 1}, Стовпець {minCol + 1})");
        }
        private static void SolveNonLinearEquation()
        {
            Console.WriteLine("Рівняння: f(x) = (x^2 - 5x + 7)^2 - (x - 2)(x - 3) - 1 = 0");

            // 1. Введення інтервалу та точності
            Console.Write("Введіть початок інтервалу (a): ");
            if (!double.TryParse(Console.ReadLine(), out double a)) return;

            Console.Write("Введіть кінець інтервалу (b): ");
            if (!double.TryParse(Console.ReadLine(), out double b)) return;

            Console.Write("Введіть точність (epsilon, напр. 0,001): ");
            // Використовуємо replace, щоб дозволити і крапку, і кому
            string epsInput = Console.ReadLine().Replace('.', ',');
            if (!double.TryParse(epsInput, out double epsilon)) epsilon = 0.001;

            // 2. Перевірка умови бісекції (функція має змінювати знак на кінцях)
            double fa = Function(a);
            double fb = Function(b);

            if (fa * fb > 0)
            {
                Console.WriteLine("\n[УВАГА] На заданому інтервалі функція не змінює знак (f(a) * f(b) > 0).");
                Console.WriteLine($"f({a}) = {fa:F4}");
                Console.WriteLine($"f({b}) = {fb:F4}");
                Console.WriteLine("Метод бісекції застосувати неможливо (або коренів немає, або їх парна кількість).");
                Console.WriteLine("ПІДКАЗКА: Це рівняння математично завжди > 0.8. Можливо, ви забули '-1' в кінці?");
                return;
            }

            // 3. Алгоритм половинного ділення
            double x = 0; // Це буде наш корінь
            int iterations = 0;

            Console.WriteLine("\nПошук кореня...");

            while (Math.Abs(b - a) > epsilon)
            {
                x = (a + b) / 2;     // Знаходимо середину
                double fx = Function(x);

                if (Math.Abs(fx) < epsilon) // Якщо ми потрапили точно в нуль (або дуже близько)
                    break;

                // Звужуємо інтервал: вибираємо ту половину, де знаки різні
                if (fa * fx < 0)
                {
                    b = x;
                    fb = fx;
                }
                else
                {
                    a = x;
                    fa = fx;
                }
                iterations++;
            }

            // 4. Виведення результату
            x = (a + b) / 2; // Уточнюємо фінальне значення
            Console.WriteLine($"\nЗнайдений корінь x = {x:F5}");
            Console.WriteLine($"Кількість ітерацій: {iterations}");

            // 5. Перевірка (Verification)
            double checkValue = Function(x);
            Console.WriteLine($"\nПеревірка: підставляємо x у рівняння -> f(x) = {checkValue:F10}");
            if (Math.Abs(checkValue) < epsilon * 10) // Допуск трохи більший через похибку округлення
                Console.WriteLine("Результат ВІРНИЙ (значення близьке до 0).");
            else
                Console.WriteLine("Результат НЕТОЧНИЙ (можливо, потрібна більша кількість ітерацій).");
        }

        // Окрема функція для обчислення значення рівняння
        private static double Function(double x)
        {

            // ВАРІАНТ ДЛЯ ПЕРЕВІРКИ (якщо у завданні одруківка і там мало бути "-1"):
            return Math.Pow(x * x - 5 * x + 7, 2) - (x - 2) * (x - 3) - 1;
        }
        private static void CheckBrackets()
        {
            Console.WriteLine("Введіть рядок, що містить дужки (), [], {}:");
            string input = Console.ReadLine();

            // Лічильники для відкритих дужок
            int roundOpen = 0;  // (
            int squareOpen = 0; // [
            int curlyOpen = 0;  // {

            // Лічильники для закритих дужок
            int roundClose = 0;  // )
            int squareClose = 0; // ]
            int curlyClose = 0;  // }

            // Проходимо по кожному символу рядка
            foreach (char c in input)
            {
                switch (c)
                {
                    case '(': roundOpen++; break;
                    case ')': roundClose++; break;

                    case '[': squareOpen++; break;
                    case ']': squareClose++; break;

                    case '{': curlyOpen++; break;
                    case '}': curlyClose++; break;
                }
            }

            // Виводимо статистику
            Console.WriteLine("\n--- Результати підрахунку ---");
            Console.WriteLine($"Круглі (): відкритих {roundOpen}, закритих {roundClose}");
            Console.WriteLine($"Квадратні []: відкритих {squareOpen}, закритих {squareClose}");
            Console.WriteLine($"Фігурні {{}}: відкритих {curlyOpen}, закритих {curlyClose}");

            // Перевірка умови рівності
            bool isRoundEqual = roundOpen == roundClose;
            bool isSquareEqual = squareOpen == squareClose;
            bool isCurlyEqual = curlyOpen == curlyClose;

            Console.WriteLine("\n--- Висновок ---");
            if (isRoundEqual && isSquareEqual && isCurlyEqual)
            {
                Console.WriteLine("Послідовність правильна (кількість відкритих і закритих дужок співпадає).");
            }
            else
            {
                Console.WriteLine("Послідовність НЕправильна (кількість не співпадає):");
                if (!isRoundEqual) Console.WriteLine("- Помилка в круглих дужках ()");
                if (!isSquareEqual) Console.WriteLine("- Помилка в квадратних дужках []");
                if (!isCurlyEqual) Console.WriteLine("- Помилка у фігурних дужках {}");
            }
        }
    }
}