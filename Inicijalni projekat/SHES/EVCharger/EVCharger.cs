using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVCharger
{
    public class EVCharger
    {
        private double maxPowerBattery;
        private double batteryCharge;

        public double MaxPowerBattery 
        {
            get { return maxPowerBattery; }

            set { value = maxPowerBattery; } 
        }

        public double BatteryCharge
        {
            get { return batteryCharge; }
            set { value = batteryCharge; }
        }
        public EVCharger()
        {

        }
        public EVCharger(double power , double charge)
        {
            MaxPowerBattery = power;
            batteryCharge = charge;
        }

        public void Charge(double power) 
        {
            if (batteryCharge + power > maxPowerBattery)
            {
                batteryCharge = maxPowerBattery;
            }
            else 
            {
                batteryCharge += power;
            }
        }

    }
}
