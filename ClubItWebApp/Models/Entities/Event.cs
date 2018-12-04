using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubItWebApp.Models.Entities
{
    public class Event: IComparable<Event>, IEquatable<Event>
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
            return this.Title.CompareTo(EventIn.Title);
        }//end CompareTo(Event)


        /// <summary>
        /// Compares two event objects based on time and title
        /// </summary>
        /// <param name="other"> The event being compared to the calling event </param>
        /// <returns> True if equal, false if not </returns>
        public bool Equals(Event other)
        {
            Boolean equals = false;
            if (Title == other.Title && Time == other.Time)
            {
                equals = true;
            }
            else
            {
                equals = false;
            }
            return equals;
        }//endIEquatable<Event>.Equals(Event)

        public override bool Equals(Object EventIn)
        {
            if (EventIn == null)
            {
                return base.Equals(EventIn);
            }
            if (!(EventIn is Event))
            {
                throw new ArgumentException("Parameter is not an Event");
            }
            else
            {
                return Equals(EventIn as Event);
            }
        }

        /// <summary>
        /// Returns a hash code based on the title and time of the event
        /// </summary>
        /// <returns> The hash code of the Event </returns>
        public override int GetHashCode()
        {
            return this.Title.GetHashCode() + this.Time.GetHashCode();
        }

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

        /// <summary>
        /// Parameterized Constructor for Event
        /// </summary>
        /// <param name="TitleIn"> The Title </param>
        /// <param name="DescIn"> The Description </param>
        /// <param name="TimeIn"> The Event Time </param>
        /// <param name="LocationIn"> The Event Location </param>
        /// <param name="BlnIn"> Whether the club admin has agreed to the terms of service </param>
        /// <param name="ImgIn"> The file path of an image </param>
        /// <param name="URLIn"> The url of a related website </param>
        /// <param name="InterestIn"> The list of members who have added the event to their calendar </param>
        public Event(String TitleIn, String DescIn, DateTime TimeIn, String LocationIn, Boolean BlnIn, String ImgIn, String URLIn, Members InterestIn)
        {
            this.Title = TitleIn;
            this.Description = DescIn;
            this.Time = TimeIn;
            this.Location = LocationIn;
            this.Agreed = BlnIn;
            this.ImagePath = ImgIn;
            this.URL = URLIn;
            this.Interest = new Members(InterestIn);
        }//end Event(String, String, DateTime, String, Boolean, String, String, Members)

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

        #endregion

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

        /// <summary>
        /// Need to display interest separately or Member and Event's toStrings will call each other infinitely
        /// </summary>
        /// <returns> The list of members that are interested in this club </returns>
        public Members GetInterest()
        {
            return this.Interest;
        }
        #endregion

        public override String ToString()
        {
            return "Title: " + Title + "\n\rDescription: " + Description + "\n\rTime: " + this.Time + "\n\rLocation: " + Location + "\n\rAgreed: " + Agreed + "\n\rImagePath: " + ImagePath + "\n\rURL: " + URL;
        }
    }
}
