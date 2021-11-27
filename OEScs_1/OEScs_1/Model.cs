using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEScs_1
{
    // Art der Zeitangabe
    enum Time
    {
        DISCR,
        CONT
    }

    // Einheiten für die Zeitangabe
    enum TimeUnit
    {
        MS,
        S,
        H,
        D,
        W,
        M,
        J
    }

    class Model
    {
        private List<string> objectTypes;
        private List<string> eventTypes;
        private Dictionary<string, double> v;
        private Dictionary<Object, int> f;

        Time time;
        public Time TimeProp => time;

        public void SetUpStatistics()
        {
            
        }

        public void ComputeFinalStatistics()
        {

        }
    }
}
