using System;
using System.Collections.Generic;
using System.Text;

namespace Bartkivskyi_Lab6_VOOP
{
    internal class SmartCar
    {
        private Engine _engine;
        private Body _body;
        private Chassis _chassis;
        private SmartSystem _smartSystem;
        private Person[] _passangers;

        public delegate void CarEventHandler(string message);
        public event CarEventHandler OnEmergency;
        public SmartCar()
        {
            _engine = new Engine();
            _body = new Body();
            _chassis = new Chassis();
            _smartSystem = new SmartSystem();
        }
        public void LoadPassangers(Person[] people)
        {
            _passangers = people;
            Console.WriteLine($"В авто сіло {_passangers.Length} людей\n");
        }
        public void StartTrip(bool isDriverIntoxicated, int driversHeartRate)
        {
            if (!_smartSystem.IsDriverAdequate(isDriverIntoxicated, driversHeartRate))
            {
                Console.WriteLine("Система безпеки скасувала поїздку\n");
                return;
            }
            _smartSystem.RegulateClimate(22.5, 40.0);
            _smartSystem.ExecuteVoiceCommand("Увімкнути музику");
            Console.WriteLine("Авто розпочало рух");
        }
        public void TriggerEmergency()
        {
            Console.WriteLine("Система виявила можливість зіткнення");
            _chassis.EmergencyStop();
        }
        public void StartEngine()
        {
            Random rnd = new Random();
            int chance = rnd.Next(1, 100);

            if (chance <= 10)
            {
                throw new CarMalfunctionException("Двигун перегрівся, тому не може бути запущений\n");
            }
            Console.WriteLine("Двигун запущено\n");
        }
        public void TriggerEmergency(string reason)
        {
            Console.WriteLine($"Знайдено проблему: {reason}");
            OnEmergency?.Invoke(reason);
        }
    }
}