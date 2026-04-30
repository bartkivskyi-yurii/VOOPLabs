using System;
using System.Collections.Generic;
using System.Text;

namespace Bartkivskyi_Lab6_VOOP
{
    internal class SmartSystem
    {
        private double _currentTemperature = 20.0;
        private double _currentHumidity = 45.0;
        public void RegulateClimate(double targetTemp, double targetHumidity)
        {
            _currentTemperature = targetTemp;
            _currentHumidity = targetHumidity;
            Console.WriteLine($"Встановлено температуру {_currentTemperature} градусів Цельсія та вологість {_currentHumidity}%\n");
        }
        public bool IsDriverAdequate(bool IsIntoxicated, int HeartRate)
        {
            if (IsIntoxicated || HeartRate > 150 || HeartRate < 40)
            {
                Console.WriteLine("Водій у неадекватному стані. Система авто заблокована\n");
                return false;
            }
            Console.WriteLine("Стан водія в нормі");
            return true;
        }
        public void ExecuteVoiceCommand(string command)
        {
            Console.WriteLine($"Голосовий помічник отримав команду {command}. Виконується");
        }
    }
}