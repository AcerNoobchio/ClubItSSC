using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    /// <summary>
    /// The container class for events, contains a single EventList and utility methods
    /// </summary>
    public class Events
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

        /// <summary>
        /// Searches for a specific event, here pretty much for convienience
        /// </summary>
        /// <param name="EventIn"> The Event Object to look for </param>
        /// <returns> The index of the found event or a negative number if search failed </returns>
        public int SearchEvents(Event EventIn)
        {
            return this.EventList.BinarySearch(EventIn);
        }//end SearchEvents(Event)

        /// <summary>
        /// Performs a quicksort O(n lg n), on the events
        /// </summary>
        public void SortEvents()
        {
            this.EventList.Sort();
        }//end SortEvents()

        public void Add(Event EventIn)
        {
            this.EventList.Add(EventIn);
        }

        public void Remove(Event EventIn)
        {
            this.EventList.Remove(EventIn);
        }

        public void RemoveAt(int Index)
        {
            this.EventList.RemoveAt(Index);
        }


        public override string ToString()
        {
            String str = "";
            for (int iCount = 0; iCount < this.EventList.Count; iCount++)
            {
                str += this.EventList[iCount];
                str += "\n\r";
            }
            return str;
        }//end ToString()

    }//end Events
}
