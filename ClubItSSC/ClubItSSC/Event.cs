using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    /// <summary>
    /// I am likely going to create some inheritance relationship (UserEvent, OfficalEvent) here, I'm not sure yet.
    /// </summary>
    class Event
    {
        private DateTime Time;      //The time at which the event will take place, will probably replace with some other datatype
        private String Location;    //The location at which the event will take place, 
        private Boolean Agreed;     //The club admin will have to check a box to agree to ETSU policy regarding events

        #region Constructors
        public Event()
        {
            Time = DateTime.Now;
            Location = "No Location Specified";
            Agreed = false;
        }//end Event()


        public Event(Event EventIn)
        {
            this.Time = EventIn.Time;
            this.Location = EventIn.Location;
            this.Agreed = EventIn.Agreed;
        }//end Event(Event)
# endregion

        #region Setters and Getters

        public void SetTime(DateTime TimeIn)
        {
            this.Time = TimeIn;
        }

        public DateTime GetTime()
        {
            return this.Time;
        }

        public void SetLocation(String LocationIn)
        {
            this.Location = LocationIn;
        }

        public String GetLocation()
        {
            return Location;
        }

        public void SetAgreed(Boolean AgreedIn)
        {
            this.Agreed = AgreedIn;
        }

        public Boolean GetAgreed()
        {
            return this.Agreed;
        }
        #endregion
    }//end Event
}
