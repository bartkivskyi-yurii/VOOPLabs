using System;
using System.Collections.Generic;
using System.Text;

namespace Bartkivskyi_Lab6_VOOP
{
    internal class FlyingSmartCar : SmartCar
    {
        private Wings _wings;
        private FlightControl _flightControl;
        private bool _isInFlightMode;
        public FlyingSmartCar() : base()
        {
            _wings = new Wings();
            _flightControl = new FlightControl();
            _isInFlightMode = false;
        }
        public void Transform()
        {
            Console.WriteLine("Розпочато трансформацію");
            if (!_isInFlightMode)
            {
                _wings.Extend();
                _isInFlightMode = true;
                Console.WriteLine("Трансформацію в режим польоту завершено\n");
            }
            else
            {
                _wings.Retract();
                _isInFlightMode = false;
                Console.WriteLine("Трансформацію в дорожній режим завершено\n");
            }
        }
        public void TakeOff()
        {
            if (!_isInFlightMode)
            {
                Console.WriteLine("Спочатку потрібно перейти в режим польлоту\n");
                return;
            }
            Console.WriteLine("Двигуни підготовлені до зльоту");
            _flightControl.SetAltitude(500);
        }
    }
}