using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClubItSSC
{
    /// <summary>
    /// I am likely going to create some inheritance relationship (UserEvent, OfficalEvent) here, I'm not sure yet.
    /// </summary>
    public class Event : IComparable<Event>
    {
        private String Title;
        private String Description;
        private DateTime Time;      //The time at which the event will take place, will probably replace with some other datatype
        private String Location;    //The location at which the event will take place, 
        private Boolean Agreed;     //The club admin will have to check a box to agree to ETSU policy regarding events
        private String ImagePath;   //The path to a file that will be optionally added to the event page
        private String URL;         //A url path to an external site with more information
        private Members Interest;   //A list of people who have added the event to their calendar

        /// <summary>
        /// Compare two events based on the event title
        /// </summary>
        /// <param name="EventIn"> The event being compared to the subject event </param>
        /// <returns> a value gt 0 if the event is higher and lt 0 if lower </returns>
        public int CompareTo(Event EventIn)
        {
            return this.Title.CompareTo(EventIn.Description);
        }//end CompareTo(Event)

        #region Constructors
        public Event()
        {
            Title = "No Title";
            Description = "No Description Entered";
            Time = DateTime.Now;
            Location = "No Location Specified";
            Agreed = false;
            ImagePath = "No File";
            URL = "www.etsu.edu";
            Interest = new Members();

        }//end Event()


        public Event(Event EventIn)
        {
            this.Title = EventIn.Title;
            this.Description = EventIn.Description;
            this.Time = EventIn.Time;
            this.Location = EventIn.Location;
            this.Agreed = EventIn.Agreed;
            this.ImagePath = EventIn.ImagePath;
            this.URL = EventIn.ImagePath;
            this.Interest = new Members(EventIn.GetInterest());

        }//end Event(Event)
# endregion

        #region Setters and Getters

        public void SetTitle(String TitleIn)
        {
            this.Title = TitleIn;
        }

        public String GetTitle()
        {
            return this.Title;
        }

        public void SetDescription(String DescIn)
        {
            this.Description = DescIn;
        }

        public String GetDescription()
        {
            return this.Description;
        }

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

        public void SetImagePath(String PathIn)
        {
            this.ImagePath = PathIn;
        }

        public void SetURL(String URLIn)
        {
            this.URL = URLIn;
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

        public String GetImagePath()
        {
            return this.ImagePath;
        }

        public String GetURL()
        {
            return this.URL;
        }

        public Members GetInterest()
        {
            return this.Interest;
        }
        #endregion

        public override String ToString()
        {
            return  "Title: "+Title+"\n\rDescription: "+Description+"\n\rTime: " + this.Time + "\n\rLocation: " + Location + "\n\rAgreed: " + Agreed + "\n\rImagePath: " + ImagePath + "\n\rURL: " + URL + "\n\rInterested Members: " +Interest;
        }
    }//end Event
}
