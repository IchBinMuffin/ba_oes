using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEScs_1
{
    class EventList
    {
        private List<Event> events;
        public List<Event> Events => events;

        public EventList()
        {
            events = new List<Event>();
        }

        // Fügt ein Event in eine Liste von mehreren Events
        public void Add(Event e)
        {
            // Prüfen, ob betrachtetes Event existiert 
            if (e == null) return;
            events.Add(e);

            // Sortieren die Liste aufsteigend nach occTime des Events
            events = events.OrderBy(e => e.OccTime).ToList();
        }

        // Lesen occTime des betrachteten Events aus
        public double GetNextOccuranceTime()
        {   
            // Prüfen, ob Liste leer ist
            if (events.Count == 0) return 0.0;
            
            return events[0].OccTime;
        }

        // Entfernen ein Event aus der Liste und speichern es in einer neuen Liste
        public List<Event> RemoveNextEvents()
        {
            List<Event> nextEvents = new List<Event>();

            // Prüfen, ob Liste mit Events leer ist
            if (nextEvents.Count == 0) return nextEvents;
            
            double nextTime = events[0].OccTime;

            // Alle Events mit gleicher occTime werden entfernt
            while (nextEvents.Count > 0 && events[0].OccTime == nextTime)
            {
                nextEvents.Add(events[0]);
                events.RemoveAt(0);
            }

            return nextEvents;
        }

    }
}
