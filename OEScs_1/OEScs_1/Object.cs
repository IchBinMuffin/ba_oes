using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEScs_1
{
    class Object
    {
        private int id;
        private string name;
        private Simulator sim;

        public Object(int id, string name, Simulator sim)
        {
            this.id = id;
            this.name = name;
            this.sim = sim;
            this.sim.Objects.Add(this.id, this);
        }

        public Object(string name, Simulator sim)
        {
            this.name = name;
            this.sim = sim;
            this.id = sim.Scenario.IdCounter + 1;
            this.sim.Objects.Add(this.id, this);
        }

        public override string ToString()
        {
            return $"id: {id}, name: {name}";
        }
    }
}
