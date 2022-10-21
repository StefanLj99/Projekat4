using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class EVChargerTest
    {
        [TestMethod]
        public void Test()
        {
            EVCharger.EVCharger charger = new EVCharger.EVCharger();
            charger.MaxPowerBattery = 50;
            charger.BatteryCharge = 10;

            Assert.AreEqual(charger.MaxPowerBattery, 0);
            Assert.AreEqual(charger.BatteryCharge, 0);
        }
    }
}
