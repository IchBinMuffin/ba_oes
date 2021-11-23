using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEScs_1
{
    abstract class Event
    {
        private double occTime;
        public double OccTime => occTime;

        public Event(double occTime)
        {
            this.occTime = occTime;
        }

        public override string ToString()
        {
            return $"occTime: {occTime}";
        }
        public abstract List<Event> OnEvent();
    }
}
