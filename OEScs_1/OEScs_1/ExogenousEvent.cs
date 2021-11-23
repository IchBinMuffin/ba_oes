using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEScs_1
{
    abstract class ExogenousEvent : Event
    {
        public ExogenousEvent(double occTime):base(occTime)
        {
        }

        public abstract double Recurrence();
        public abstract Event NextEvent();
    }
}
