using System;
using Diagnostico2019.Exercises;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class TestOhmLaw
    {
        [TestMethod]
        public void GetVoltage()
        {
            Assert.IsTrue(OhmLaw.CalculateVoltage(10, 20) == 200);
        }

        [TestMethod]
        public void GetCurrent()
        {
            Assert.IsTrue(OhmLaw.CalculateCurrent(200, 20) == 10);
        }

        [TestMethod]
        public void GetResistance()
        {
            Assert.IsTrue(OhmLaw.CalculateCurrent(200, 10) == 20);
        }
    }
}
