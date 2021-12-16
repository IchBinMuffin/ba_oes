using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEScs_1
{
	class MathLib
	{
		private Dictionary<string, Func<double[], double>> summary = InitSummaryDict();

		private static Dictionary<String, Func<double[], double>> InitSummaryDict()
		{
			Dictionary<String, Func<double[], double>> summaryDict = new Dictionary<string, Func<double[], double>>();
			summaryDict.Add("Average", MathLib::Mean);
			summaryDict.Add("Std.dev.", MathLib::StdDev);
			summaryDict.Add("Minimum", MathLib::MinValue);
			summaryDict.Add("Maximum", MathLib::MaxValue);
			summaryDict.Add("CI Lower", MathLib::CIlower);
			summaryDict.Add("CI Upper", MathLib::CIupper);
			return summaryDict;
		}

		// Berechnet die Summe aller Elemente einer Liste
		private double SumValues(double[] data)
        {
			return data.Sum();
        }

		// Berechnet den Durchschnitt (arithm. Mittel) aller Elemente einer Liste
		public double Mean(double[] data)
        {
			return SumValues(data) / data.Length;
        }

		// Rundet einen Wert
		private double RoundValue(double input, double decimalPlaces)
        {
			double roundingFactor = Math.Pow(10, decimalPlaces);
			return Math.Round((input + double.Epsilon) * roundingFactor) / roundingFactor;
        }

		// Filtert das größte Element aus einer Liste
		private double MaxValue(double[] data)
        {
			return data.Max();
        }

		// Filtert das kleinste Element aus einer Liste
		private double MinValue(double[] data)
		{
			return data.Min();
		}

		// Ermittelt die Standard Abweichung (Varianz) einer Liste
		private double StdDev(double[] data)
        {
			double x = Mean(data);
			double stdDeviation = 0.0;

            for (int i = 0; i < data.Length; i++)
            {
				double num = data[i];
				stdDeviation += Math.Pow(num - x, 2);
            }

			return RoundValue(Math.Sqrt(stdDeviation / data.Length), 2);
        }

		// Gibt einen zufälligen Integer zwischen [min, max) aus
		private static int GetUniformRandomInteger(int min, int max)
        {
			Random randy = new Random();
			return randy.Next(min, max);
        }

		// Gibt einen zufälligen Double zwischen [min, max) aus
		private static double GetUniformRandomDouble(double min, double max)
		{
			Random randy = new Random();
			return randy.NextDouble() * (max - min) + min;
		}

		// TODO Konfidenzintervall
	}

}
