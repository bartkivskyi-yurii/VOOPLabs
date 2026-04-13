using System;
using System.Collections.Generic;
using System.Text;

namespace Bartkivskyi_Lab3_VOOP
{
    internal static class CreativeWork
    {
        public static int[] arr;
        public static void GenerateArr(int n, int min, int max)
        {
            Random rand = new Random();
            arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = rand.Next(min, max + 1);
            Console.WriteLine("\nЗгенеровано масив: " + string.Join(", ", arr) + '\n');
        }
        public static void InsertionSort(int n, int[] arr)
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
        public static void CheckBrackets()
        {
            Console.WriteLine("Введіть рядок, що містить дужки (), [], {}:");
            string input = Console.ReadLine();

            int roundOpen = 0;
            int squareOpen = 0;
            int curlyOpen = 0;

            int roundClose = 0;
            int squareClose = 0;
            int curlyClose = 0;

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

            Console.WriteLine("\n--- Результати підрахунку ---");
            Console.WriteLine($"Круглі (): відкритих {roundOpen}, закритих {roundClose}");
            Console.WriteLine($"Квадратні []: відкритих {squareOpen}, закритих {squareClose}");
            Console.WriteLine($"Фігурні {{}}: відкритих {curlyOpen}, закритих {curlyClose}");

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
        public static void RearrangeArray()
        {
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Масив порожній.");
                return;
            }

            int positionToInsert = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    arr[positionToInsert] = arr[i];
                    positionToInsert++;
                }
            }

            while (positionToInsert < arr.Length)
            {
                arr[positionToInsert] = 0;
                positionToInsert++;
            }

            Console.WriteLine("Масив переформовано (нулі в кінці): " + string.Join(", ", arr));
        }
    }
}