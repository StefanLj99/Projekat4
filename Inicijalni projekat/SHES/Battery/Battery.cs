using System;
using System.Collections.Generic;
using System.Text;

namespace Battery
{
    public class Battery
    {
        private string nameBattery;
        private double maxPowerBattery;
        private double capacityBattery;

        public string NameBattery
        {
            get { return nameBattery; }
            set { nameBattery = value; }
        }
        public double MaxPowerBattery
        {
            get { return maxPowerBattery; }
            set { maxPowerBattery = value; }
        }
        public double CapacityBattery
        {
            get { return capacityBattery; }
            set { capacityBattery = value; }
        }

        public Battery()
        {

        }
        public Battery(string nameB, double powerB, double capacityB)
        {
            NameBattery = nameB;
            MaxPowerBattery = powerB;
            CapacityBattery = capacityB;

        }

        public double Add(double minutesA)
        {

            double minutes = capacityBattery * 60;

            if (minutes + minutesA > maxPowerBattery)
            {
                minutes = maxPowerBattery;
            }
            else
            {
                minutes = minutes + minutesA;
            }

            capacityBattery = minutes / 60;

            return capacityBattery;

        }
        public double Subtraction(double minutesS)
        {
            double minutes = capacityBattery * 60;

            if (minutes - minutesS < 0)
            {
                minutes = 0;
            }
            else
            {
                minutes = minutes - minutesS;
            }

            capacityBattery = minutes / 60;

            return capacityBattery;
        }

    }
}
