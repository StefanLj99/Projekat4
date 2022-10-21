using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    public class Utility
    {
        private double powerExchage;
        private double price;

        public double PowerExcage
        {
            get { return powerExchage; }
            set { powerExchage = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public Utility()
        {

        }
        public Utility(double powerE, double pricee)
        {
            PowerExcage = powerE;
            Price = pricee;
        }

        public double Sell(double power)
        {
            powerExchage -= power;

            return price * power;
        }

        public double Buy(double power)
        {
            powerExchage -= power;

            return price * power;
        }
    }
}
