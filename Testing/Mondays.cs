using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diagnostico2019.Exercises;

namespace Testing
{
    [TestClass]
    public class TestMondays
    {
        [TestMethod]
        public void GetMondays()
        {
            foreach (var date in Dates.GetDays(DateTime.Now, DateTime.Now.AddYears(1), DayOfWeek.Monday))
            {
                Assert.IsTrue(date.DayOfWeek == DayOfWeek.Monday);
            }
        }
    }
}
