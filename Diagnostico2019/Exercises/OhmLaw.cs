using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostico2019.Exercises
{
    public static class OhmLaw
    {
        public static void ShowMenu()
        {
            Menu menu = new Menu("Ohm's Calculator", "Select what you want to calculate.");
            menu.AddOption(GetVoltage, "Calculates the voltage from current and resistance.");
            menu.AddOption(GetCurrent, "Calculates the current from voltage and resistance.");
            menu.AddOption(GetResistance, "Calculates the resistance from voltage and current.");

            //menu.ShowMenu();

            while (!menu.Exit)
            {
                Console.Clear();
                menu.ShowMenu();
                menu.GetSelection();
            }
        }

        private static void GetVoltage()
        {
            ShowResult(GetResult("Current", "Resistance", CalculateVoltage));
        }

        private static void GetCurrent()
        {
            ShowResult(GetResult("Voltage", "Resistance", CalculateCurrent));
        }

        private static void GetResistance()
        {
            ShowResult(GetResult("Voltage", "Current", CalculateResistance));
        }

        private static void ShowResult(string result)
        {
            Console.WriteLine(Environment.NewLine + "The result is " + result);
        }

        private static string GetResult(string firstText, string secondText, Func<decimal, decimal, decimal> formula)
        {
            int value1 = IOHelper.GetNumericInput($"Insert the { firstText }: ");
            int value2 = IOHelper.GetNumericInput($"Insert the { secondText }: ");

            return formula.Invoke(value1, value2).ToString();
        }

        public static decimal CalculateVoltage(decimal current, decimal resistance)
        {
            return current * resistance;
        }

        public static decimal CalculateCurrent(decimal voltage, decimal resistance)
        {
            return voltage / resistance;
        }

        public static decimal CalculateResistance(decimal voltage, decimal current)
        {
            return voltage / current;
        }
    }
}
