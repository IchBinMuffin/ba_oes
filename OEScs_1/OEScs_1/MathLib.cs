using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

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

		// Berechnen des kartesischen Produktes (siehe https://stackoverflow.com/a/40202076)
		private static int[][] CartesianProduct(int[] s1, int[] s2) 
		{
			List<int[]> list = new List<int[]>();
            foreach (int i in s1)
            {
				int v1 = i;
                foreach (int j in s2)
                {
					int v2 = j;
					list.Add(new int[] { v1, v2 });
				}
            }

			int[][] result = new int[list.Count()][];
			int k = 0;

			foreach (int[] i in list)
			{
				result[k++] = i;
			}

			return result;
		}

		/*
		private static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences) 
		{
			https://rosettacode.org/wiki/Cartesian_product_of_two_or_more_lists#C.23
		}*/

		// TODO Konfidenzintervall
		private double Confidence(double Arg1, double Arg2, double Arg3) 
		{
			return 0.0;
		}
	}

}
