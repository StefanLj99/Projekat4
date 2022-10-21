using System;
using System.Collections.Generic;
using System.Text;

namespace Solar_panels
{
    public class SolarniPanel
    {
        private string namePanel;
        private double maxPowerPanel;

        public string NamePanel
        {
            get { return namePanel; }
            set { namePanel = value; }
        }
        public double MaxPowerPanel
        {
            get { return maxPowerPanel; }
            set { maxPowerPanel = value; }
        }

        public SolarniPanel()
        {

        }
        public SolarniPanel(string name, double power)
        {
            NamePanel = name;
            MaxPowerPanel = power;

        }

        public double GetPower(double number)
        {
            return (maxPowerPanel * number) / 100;
        }





    }
}
