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

        // Consumer<Simulator>... -> Represents an operation that accepts a single input argument and returns no result. Unlike most other functional interfaces, Consumer is expected to operate via side-effects. 
        public void SetUpInitialState()
        {

        }
    }
}
