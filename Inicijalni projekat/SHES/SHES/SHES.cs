using Battery;
using Consumers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;

namespace SHES
{
    public class SHES
    {
        List<Battery.Battery> batteries = new List<Battery.Battery>();
        List<Solar_panels.SolarniPanel> panels = new List<Solar_panels.SolarniPanel>();
        List<Consumers.Consumers> consumers = new List<Consumers.Consumers>();
        Utility.Utility utility = new Utility.Utility();
        bool isStarted = false;
        double sunPercent = 0;

        private double sunPower = 0;
        private bool isOnCharger = false;
        private bool doWeWantCharging = false;
        private double charged = 0;

        public double SunPower
        {
            get { return sunPower; }
            set { value = sunPower; }
        }

        public bool IsOnCharger
        {
            get { return isOnCharger; }
            set { value = isOnCharger; }
        }

        public bool DoWeWantCharging
        {
            get { return doWeWantCharging; }
            set { value = doWeWantCharging; }
        }

        public double Charged
        {
            get { return charged; }
            set { charged = value; }
        }


        public SHES()
        {
            Battery.Battery battery = new Battery.Battery("baterija1", 5, 200);
            batteries.Add(battery);
            Battery.Battery battery2 = new Battery.Battery("baterija2", 8, 100);
            batteries.Add(battery2);

            Solar_panels.SolarniPanel solarniPanel = new Solar_panels.SolarniPanel("Panel1", 45);
            panels.Add(solarniPanel);
            Solar_panels.SolarniPanel solarniPanel2 = new Solar_panels.SolarniPanel("Panel2", 75);
            panels.Add(solarniPanel2);

            Consumers.Consumers consumer = new Consumers.Consumers("Consumer1", 30);
            consumers.Add(consumer);
            Consumers.Consumers consumer2 = new Consumers.Consumers("Consumer2", 80);
            consumers.Add(consumer);

            isStarted = true;
            Do();

        }

        public void Do()
        {
            new Thread(() => {

                do
                {
                    double power = Calculate();

                    if (power > 0)
                    {
                        utility.Sell(power);
                    }
                    else
                    {
                        utility.Buy(power);
                    }

                    WriteToDatabase(power, utility.Price);

                    Thread.Sleep(1 * 1000);

                } while (isStarted);

            });
        }

        public void WriteToDatabase(double calculation, double price)
        {
            string sqlConnection = @"Server=DESKTOP-LAGEU8N\SQLEXPRESS;Database=res;Trusted_Connection=True;";

            SqlConnection conection = new SqlConnection(sqlConnection);

            try
            {
                conection.Open();

                double batteryPower = 0;

                foreach (Battery.Battery battery in batteries)
                {
                    int hour = DateTime.Now.Hour;

                    if (hour >= 3 && hour <= 6)
                    {
                        battery.Add(1);
                        batteryPower += 1;
                    }

                    if (hour >= 14 && hour <= 17)
                    {
                        battery.Subtraction(1);
                        batteryPower -= 1;
                    }

                }

                double consumerPower = 0;
                foreach (Consumers.Consumers consumer in consumers)
                {
                    consumerPower -= consumer.Consumption;
                }

                double solarPanelsPower = 0;
                foreach (Solar_panels.SolarniPanel pannel in panels)
                {
                    solarPanelsPower += pannel.GetPower(sunPercent);
                }

                string sql = "insert into RES(BATTERY, SOLAR_PANEL, PRICE, UTILITY_POWER, CONSUMERS, MEASURMENT_DATE) " +
                    "valuess(" + batteryPower + "," + solarPanelsPower + "," + price + "," + calculation + "," + consumerPower + "," + DateTime.Now + ")";

                SqlCommand command = new SqlCommand(sql, conection);
                command.ExecuteNonQuery();

                command.Dispose();
                conection.Close();



            }
            catch (Exception e)
            {

                conection.Close();
            }


        }

        public void Start()
        {
            isStarted = true;
        }

        public void End()
        {
            isStarted = false;
        }

        public double Calculate()
        {
            double power = 0;

            foreach (Solar_panels.SolarniPanel pannel in panels)
            {
                power += pannel.GetPower(sunPercent);
            }

            foreach (Battery.Battery battery in batteries)
            {
                int hour = DateTime.Now.Hour;

                if (hour >= 3 && hour <= 6)
                {
                    battery.Add(1);
                    power += 1;
                }

                if (hour >= 14 && hour <= 17)
                {
                    battery.Subtraction(1);
                    power -= 1;
                }

            }

            foreach (Consumers.Consumers consumer in consumers)
            {
                power -= consumer.Consumption;
            }

            return power;
        }
    }
}
