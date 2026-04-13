using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Bartkivskyi_Lab3_VOOP
{
    public partial class Student
    {
        public partial class ContestWork
        {
            public string ContestName { get; set; }
            public string WorkTitle { get; set; }
            public int ArticlesCount { get; set; }
            public ContestWork(string contestName, string workTitle, int articlesCount)
            {
                ContestName = contestName;
                WorkTitle = workTitle;
                ArticlesCount = articlesCount;
            }
            public void CheckRelavent(string themesFileName)
            {
                Console.WriteLine($"\nПеревірка роботи \"{WorkTitle}\" на відповідність тематиці");
                string[] keyWords = WorkTitle.Split(new char[] { ' ', ',', '.', '-', ':' }, StringSplitOptions.RemoveEmptyEntries);

                bool foundMatch = false;

                if (File.Exists(themesFileName))
                {
                    string[] fileLines = File.ReadAllLines(themesFileName);

                    foreach (string line in fileLines)
                    {
                        foreach (string word in keyWords)
                        {
                            if (line.Contains(word, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.Write($"Знайдено збіг у рядку: {line}");
                                foundMatch = true;
                                break;
                            }
                        }
                    }
                    if (!foundMatch)
                    {
                        Console.WriteLine("Збігів з тематикою конкурсу не знайдено.");
                    }
                }
                else
                {
                    Console.WriteLine($"Помилка: Файл {themesFileName} не знайдено!");
                }
            }
        }
    }
}