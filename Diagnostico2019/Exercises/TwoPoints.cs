using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostico2019.Exercises
{
    public static class TwoPoints
    {
        public static void GetDistance()
        {
            var pointA = GetNewPoint("A");
            Console.WriteLine(Environment.NewLine);
            var pointB = GetNewPoint("B");

            Console.WriteLine(Environment.NewLine + Environment.NewLine);

            Console.WriteLine("The distance is: " + CalculateDistance(pointA, pointB).ToString());
        }

        private static double[] GetNewPoint(string pointName)
        {
            return new double[]
            {
                IOHelper.GetNumericInput($"Please insert value X for point { pointName }"),
                IOHelper.GetNumericInput($"Please insert value Y for point { pointName }"),
            };
        }

        public static double CalculateDistance(double[] pointA, double[] pointB)
        {
            return Math.Sqrt(Math.Pow(pointB[0] - pointA[0], 2) + Math.Pow(pointB[1] - pointA[1], 2));
        }
    }
}
