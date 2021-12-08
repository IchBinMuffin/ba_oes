﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEScs_1
{
    class Simulator
    {
        // Attribute
        private int step;
        private double time;
        private double endTime;
        private int idCounter;
        private long nextMomentDeltaT = 1L;
        private double nextEventTime = 0.0;

        // Dictionarys
        private Dictionary<string, double> stat = new Dictionary<string, double>(); // Dictionary für statistische Daten
        private Dictionary<int, Object> objects = new Dictionary<int, Object>(); // Dictionary mit allen Objekten (erreichbar durch ID)

        // Klassen
        private Scenario scenario = new Scenario();
        private Model model;
        private ExperimentType experimentType;
        private EventList FEL = new EventList(); // FEL - Future Event List

        // Probs (Getter)
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

            // setzen der standard Endzeit
            if (this.scenario.DurationInSimTime > 0.0)
            {
                this.endTime = this.scenario.DurationInSimTime;
            }
            else
            {
                this.endTime = double.MaxValue;
            }

            // setzen eines standard Wertes für idCounter, falls keine ID vom Szenario
            if (this.scenario.IdCounter > 0)
            {
                this.idCounter = this.scenario.IdCounter;
            }
            else
            {
                this.idCounter = 1000;
            }

            // Aufsetzen des initialen Zustands
            this.scenario.GetSetUpInitialState?.Invoke(this);
            this.model.GetSetUpStatistics?.Invoke(this);
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

                List<Event> nextEvents = this.FEL.RemoveNextEvents();        

                for (int i = 0; i < nextEvents.Count(); i++)
                {
                    Event e = nextEvents[i];
                    List<Event> followUpEvents = e.OnEvent();

                    /*  for (eVENT f : followUpEvents) {
		                 this.FEL.add(f); }
		            */
                    for (int j = 0; j < followUpEvents.Count(); j++)
                    {
                        Event f = followUpEvents[j];
                        this.FEL.Add(f);
                    }

                    // Prüfen, ob e ein ExogenousEvent ist 
                    if (e.GetType() == typeof(ExogenousEvent)) this.FEL.Add(((ExogenousEvent)e).NextEvent());
                }
            }

            this.model.GetComputeFinalStatistics?.Invoke(this);       
                 
        }


        // Ausführen eines Standalone Szenarios
        public void runStandaloneScenario()
        {
            this.InitializeSimulator();
            this.InitializeScenarioRun();
            this.RunScenario();
        }


        // Ausführen eines simplen Experiments
        public void RunExperiment(ExperimentType exp)
        {
            Dictionary<double, Dictionary<string, double>> experimentStats = new Dictionary<double, Dictionary<string, double>>();
            Dictionary<string, Dictionary<string, double>> sumStat = new Dictionary<string, Dictionary<string, double>>();

            this.InitializeSimulator();

            // Initiales Aufsetzen für Aufnahme der Statistiken der Replikationen
            this.model.GetSetUpStatistics?.Invoke(this);
            exp.ReplicStat.Clear();
            foreach (string key in this.stat.Keys)
            {
                exp.ReplicStat.Add(key, new double[exp.NmrOfReplications]);
            }

            // Ausführen der Experiment Szenario Replikationen
            for (int i = 0; i < exp.NmrOfReplications; i++)
            {
                this.InitializeScenarioRun();
                this.RunScenario();

                // Speichern der Statistiken der Replikationen
                foreach (KeyValuePair<string, double[]> keyPair in exp.ReplicStat)
                {                   
                    double[] storeValue = keyPair.Value;
                    storeValue[i] = this.stat[keyPair.Key];
                    keyPair.Value.SetValue(storeValue, i);
                }

                // Ausgabe...

                experimentStats.Add(i, new Dictionary<string, double>(this.stat));
            }

            // Zusammenfassen aller Statistiken 
            exp.SummaryStat.Clear();
            foreach (KeyValuePair<string, double[]> pair in exp.ReplicStat)
            {
                // Ausgabe...

                Dictionary<string, double> mathStats = new Dictionary<string, double>();
                foreach (KeyValuePair<string, Func<double[], double>> stat in collection)
                {
                    // TODO Collection = Math Libary Klasse (fertig stellen)
                }
            }
        }

    }
}
