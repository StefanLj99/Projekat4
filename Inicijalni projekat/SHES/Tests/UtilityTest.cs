using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class UtilityTest
    {
        [TestMethod]
        public void Test()
        {
            Utility.Utility utility = new Utility.Utility();
            utility.PowerExcage = 20;
            utility.Price = 100;

            Assert.AreEqual(utility.PowerExcage, 20);
            Assert.AreEqual(utility.Price, 100);
            Assert.AreEqual(utility.Sell(5), 500);
            Assert.AreEqual(utility.Buy(20), 2000);
        }
    }
}
