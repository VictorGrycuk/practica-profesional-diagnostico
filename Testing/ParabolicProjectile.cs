using System;
using Diagnostico2019.Exercises;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class TestParabolicProjectile
    {
        readonly int velocity = 18;
        readonly int angle = 40;

        [TestMethod]
        public void CalculateDistance()
        {
            Assert.IsTrue((int)ParabolicProjectile.CalculateMaximumDistance(velocity, angle) == 32);
        }

        [TestMethod]
        public void CalculateHeight()
        {
            Assert.IsTrue((int)ParabolicProjectile.CalculateMaximumHeight(velocity, angle) == 6);
        }
    }
}
