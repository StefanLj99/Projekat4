using System;
using System.Collections.Generic;
using System.Text;

namespace Consumers
{
    public class Consumers
    {
        private string nameConsumer;
        private double consumption;

        public string NameConsumer
        {
            get { return nameConsumer; }
            set { nameConsumer = value; }
        }
        public double Consumption
        {
            get { return consumption; }
            set { consumption = value; }
        }

        public Consumers()
        {

        }
        public Consumers(string nameC, double consu)
        {
            NameConsumer = nameC;
            Consumption = consu;
        }
    }
}
