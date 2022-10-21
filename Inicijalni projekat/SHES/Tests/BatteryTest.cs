using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Tests
{
    [TestClass]
    public class BatteryTest
    {
        [TestMethod]
        public void Test()
        {
            Battery.Battery battery = new Battery.Battery();
            battery.CapacityBattery = 15;
            battery.MaxPowerBattery = 9;
            battery.NameBattery = "NAME";

            Assert.AreEqual(battery.CapacityBattery, 15);
            Assert.AreEqual(battery.MaxPowerBattery, 9);
            Assert.AreEqual(battery.NameBattery, "NAME");

            Assert.AreEqual(battery.Add(10), 0.15);
            Assert.AreEqual(battery.Subtraction(20), 0);

        }

    }
}
