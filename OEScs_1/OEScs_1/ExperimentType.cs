using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEScs_1
{
    class ExperimentType
    {
        private string title;
        private int nmrOfReplications;
        private Dictionary<string, double[]> replicStat = new Dictionary<string, double[]>();
        private Dictionary<string, Dictionary<string, double>> summaryStat = new Dictionary<string, Dictionary<string, double>>();

        public Dictionary<string, double[]> ReplicStat => replicStat;
        public int NmrOfReplications => nmrOfReplications;
        public Dictionary<string, Dictionary<string, double>> SummaryStat => summaryStat;

        public ExperimentType(string title, int nmrOfReplications)
        {
            this.title = title;
            this.nmrOfReplications = nmrOfReplications;
        }
    }
}
