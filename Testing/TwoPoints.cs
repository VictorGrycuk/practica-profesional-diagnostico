using Diagnostico2019.Exercises;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class TestTwoPoints
    {
        [TestMethod]
        public void CalculateDistance()
        {
            var pointA = new double[] { 2, 5 };
            var pointB = new double[] { 7, -2 };
            Assert.IsTrue(TwoPoints.CalculateDistance(pointA, pointB) == 8.6023252670426267);
        }
    }
}
