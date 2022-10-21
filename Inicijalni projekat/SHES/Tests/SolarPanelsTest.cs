using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class SolarPanelsTest
    {
        [TestMethod]
        public void Test()
        {
            Solar_panels.SolarniPanel panel = new Solar_panels.SolarniPanel();
            panel.NamePanel = "Name";
            panel.MaxPowerPanel = 100;

            Assert.AreEqual(panel.NamePanel, "Name");
            Assert.AreEqual(panel.MaxPowerPanel, 100);
            Assert.AreEqual(panel.GetPower(15), 15);
        }
    }
}
