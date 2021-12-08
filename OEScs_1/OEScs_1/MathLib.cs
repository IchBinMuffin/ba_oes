using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEScs_1
{
	class MathLib
	{
		private Dictionary<string, Func<double[], double>> summary = initSummaryDict();

		private static Dictionary<String, Func<double[], double>> initSummaryDict()
		{
			Dictionary<String, Func<double[], double>> summaryDict = new Dictionary<string, Func<double[], double>>();
			summaryDict.Add("Average", MathLib::average);
			summaryDict.Add("Std.dev.", MathLib::stdDev);
			summaryDict.Add("Minimum", MathLib::min);
			summaryDict.Add("Maximum", MathLib::max);
			summaryDict.Add("CI Lower", MathLib::CIlower);
			summaryDict.Add("CI Upper", MathLib::CIupper);
			return summaryDict;
		}

		public double average(double data)
        {
			return sum(data) / data.length;
        }
	}

}
