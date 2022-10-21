using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class SHESTest
    {
        [TestMethod]
        public void Test()
        {
            SHES.SHES shes = new SHES.SHES();
            shes.SunPower = 8;
            shes.Charged = 15;
            shes.DoWeWantCharging = true;
            shes.IsOnCharger = true;

            Assert.AreEqual(shes.SunPower, 0);
            Assert.AreEqual(shes.Charged, 15);
            Assert.AreEqual(shes.DoWeWantCharging, false);
            Assert.AreEqual(shes.IsOnCharger, false);
        }
    }
}
