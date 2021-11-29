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

        // Initialisieren einen Szenario Durchlauf
        public void InitializeScenarioRun()
        {
            this.objects.Clear();
            this.FEL.Events.Clear();
            this.step = 0;
            this.time = 0.0;
            
            // TODO Scenario beenden und dann diese Funktion
        }

        // Inkrementieren der Simulationszeit
        public void AdvanceSimulationTime()
        {
            // 0.0 wenn kein Event
            this.nextEventTime = this.FEL.GetNextOccuranceTime();

            // Erhöhen den Step Counter um 1
            this.step++;

            // Prüfen, ob eine Eventzeit vorliegt und rücken in der Zeit voran
            if (this.nextEventTime > 0) this.time = this.nextEventTime;
            
        }

        // Ausführen eines Szenarios einer Simulation
        public void RunScenario()
        {
            while (this.time < this.endTime && this.FEL.Events.Count > 0)
            {
                this.AdvanceSimulationTime();

                List<Event> upcomingEvents = this.FEL.RemoveNextEvents();
                Event e;

                for (// TODO e : upcomingEvents)
                {

                    /* Der ternäre Operator besteht aus drei Segmenten. 
                     * Der erste ist ein bedingter Ausdruck, 
                     * der einen booleschen Wert zurückgibt. 
                     * Der zweite und dritte Wert sind die Werte vor und nach dem 
                     * Doppelpunkt. Es gibt den Wert vor dem Doppelpunkt zurück, 
                     * wenn der bedingte Ausdruck als true ausgewertet wird. 
                     * Andernfalls wird der Wert nach zurückgegeben. 
                     * Die Syntax ist unten.*/

                }
            }
        }

        // Ausführen eines Standalone Szenarios
        public void runStandaloneScenario()
        {
            this.InitializeSimulator();
            this.InitializeScenarioRun();
            this.RunScenario();
        }

        public void RunExperiment()
        {

        }

    }
}
