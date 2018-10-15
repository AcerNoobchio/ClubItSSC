using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    class Events
    {
        private List<Event> EventList;

        #region Constructors
        public Events()
        {
            EventList = new List<Event>();
        }

        public Events(Events EventsIn)
        {
            this.EventList = EventsIn.CopyEvents();
        }
        #endregion

        #region Setters and Getters
        public List<Event> GetEventList()
        {
            return EventList;
        }

        #endregion

        /// <summary>
        /// Returns a deep copy of the list of events
        /// </summary>
        /// <returns> A copy of the event list </returns>
        public List<Event> CopyEvents()
        {
            List<Event> tempEvents = new List<Event>(this.EventList.Count);
            for (int iCount = 0; iCount < this.EventList.Count; iCount++)
            {
                tempEvents.Add(this.EventList[iCount]);
            }
            return tempEvents;
        }//end CopyMemberList(List<Event>)
    }//end Events
}
