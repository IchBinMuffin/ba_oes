using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEScs_1
{
    class Scenario
    {
        private double durationInSimTime;
        private int idCounter;

        private Model model;
        private Simulator simulator;

        public int IdCounter => idCounter;
        public double DurationInSimTime => durationInSimTime;


        private Action<Simulator> SetUpInitialState;
        public Action<Simulator> GetSetUpInitialState => SetUpInitialState;
    }
}
