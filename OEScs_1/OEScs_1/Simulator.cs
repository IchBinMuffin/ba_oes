using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEScs_1
{
    class Simulator
    {
        private int step;
        private double time;
        private double endTime;
        private int idCounter;
        private Dictionary<string, double> stat;
        private Dictionary<int, Object> objects;
        private Scenario scenario = new Scenario();

        public Dictionary<int, Object> Objects => objects;
        public Scenario Scenario => scenario;

        public void InitializeSimulator()
        {
            
        }

        public void InitializeScenarioRun()
        {

        }

        public void AdvanceSimulationTime()
        {

        }

        public void RunScenario()
        {

        }

        public void RunExperiment()
        {

        }

    }
}
