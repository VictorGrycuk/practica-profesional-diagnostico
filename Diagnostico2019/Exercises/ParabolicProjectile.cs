using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostico2019.Exercises
{
    public static class ParabolicProjectile
    {
        public static void Calculate()
        {
            var velocity = IOHelper.GetNumericInput("Please insert the VELOCITY:");
            var angle = IOHelper.GetNumericInput(Environment.NewLine + "Please insert the ANGLE:");

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"The maximum height is { CalculateMaximumHeight(velocity, angle).ToString() } " + 
                $"and the maximum horizontal distance is { CalculateMaximumDistance(velocity, angle) }");
        }

        public static double CalculateMaximumHeight(int velocity, int angle)
        {
            return (Math.Pow(velocity, 2) * Math.Pow(Math.Sin(ConvertRadtoDeg(angle)), 2)) / (9.8 * 2);
        }

        public static double CalculateMaximumDistance(int velocity, int angle)
        {
            return Math.Pow(velocity, 2) * Math.Sin(2 * ConvertRadtoDeg(angle)) / 9.8;
        }

        private static double ConvertRadtoDeg(int value)
        {
            return value * Math.PI / 180;
        }
    }
}
