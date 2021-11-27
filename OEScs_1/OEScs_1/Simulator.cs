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

        private long nextMomentDeltaT = 1L;
        private double nextEventTime = 0.0;

        private Dictionary<int, Object> objects;
        private Scenario scenario = new Scenario();
        private Model model;
        private ExperimentType experimentType;
        private EventList FEL = new EventList();

        public Dictionary<int, Object> Objects => objects;
        public Scenario Scenario => scenario;

        // Initialisieren des Simulators
        public void InitializeSimulator()
        {
            if (this.model.TimeProp == Time.DISCR)
            {
                this.nextMomentDeltaT = 1L;
            } else
            {
                this.nextMomentDeltaT = 2L;
            }
        }

        //  Initialisieren einen Szenario Durchlauf
        public void InitializeScenarioRun()
        {
            this.objects.Clear();
            this.FEL.Clear();
            this.step = 0;
            this.time = 0.0;
            
            // TODO Scenario beenden und dann diese Funktion
        }

        public void AdvanceSimulationTime()
        {
            // 0.0 wenn kein Event
            this.nextEventTime = this.FEL.GetNextOccuranceTime();

            // Erhöhen den Step Counter um 1
            this.step++;

            // Prüfen, ob eine Eventzeit vorliegt und rücken in der Zeit voran
            if (this.nextEventTime > 0) this.time = this.nextEventTime;
            
        }

        public void RunScenario()
        {

        }

        public void RunExperiment()
        {

        }

    }
}
