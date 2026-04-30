using System;
using System.Collections.Generic;
using System.Text;

namespace Bartkivskyi_Lab6_VOOP
{
    internal class Chassis
    {
        private RunningGear _runningGear;
        private Stearing _stearing;
        private Transmission _transmission;
        private BrakingSystem _brakingSystem;
        public Chassis()
        {
            _runningGear = new RunningGear();
            _stearing = new Stearing();
            _transmission = new Transmission();
            _brakingSystem = new BrakingSystem();
        }
        public void EmergencyStop()
        {
            _brakingSystem.ApplyBrakes();
        }
    }
}