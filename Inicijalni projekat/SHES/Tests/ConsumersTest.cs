using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class ConsumersTest
    {
        [TestMethod]
        public void Test()
        {
            Consumers.Consumers consumers = new Consumers.Consumers();
            consumers.NameConsumer = "Consumer";
            consumers.Consumption = 20;

            Assert.AreEqual(consumers.NameConsumer, "Consumer");
            Assert.AreEqual(consumers.Consumption, 20);
        }
    }
}
