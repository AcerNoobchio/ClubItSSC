using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubItWebApp.Models.Entities
{
    public class Club  //: IComparable<Club>
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public ICollection<Member> Members { get; set; }
        public ICollection<Event> Events { get; set; }

       
        private Members MemberList;
        private Member President;
        private Events EventList;
        private Announcements AnnounceHistory;

        /// <summary>
        /// Compare two events based on the club title
        /// </summary>
        /// <param name="ClubIn"> The club to be compared to the calling club </param>
        /// <returns> a value gt 0 if the event is higher and lt 0 if lower </returns>
        public int CompareTo(Club ClubIn)
        {
            return this.Name.CompareTo(ClubIn.Name);
        }//end CompareTo(Club)

        #region Constructors
        public Club()
        {
            Name = "No Name Set";
            Description = "No Description Entered";
            Active = false;
            MemberList = new Members();
            President = new Member();
            AnnounceHistory = new Announcements();
            EventList = new Events();
        }//end Club()

        /// <summary>
        /// Parameterized Constructor for Club
        /// </summary>
        /// <param name="NameIn"> The Name of the club </param>
        /// <param name="DescriptionIn"> The description of the club </param>
        /// <param name="ActiveIn"> Whether or not the club has been activiated </param>
        /// <param name="MemberListIn"> The list of members in the club </param>
        /// <param name="PresidentIn"> The president of the club </param>
        /// <param name="AnnounceIn"> The List of announcements that the club has made </param>
        /// <param name="EventsIn"> The List of events in the club's history </param>
        public Club(String NameIn, String DescriptionIn, Boolean ActiveIn, Members MemberListIn, Member PresidentIn, Announcements AnnounceIn, Events EventsIn)
        {
            this.Name = NameIn;
            this.Description = DescriptionIn;
            this.Active = ActiveIn;
            this.MemberList = new Members(MemberListIn);
            this.President = new Member(PresidentIn);
            this.AnnounceHistory = new Announcements(AnnounceIn);
            this.EventList = new Events(EventsIn);
        }//end Club(String, String, Boolean, Members, Member, Announcement, Event)

        public Club(Club ClubIn)
        {
            this.Name = ClubIn.Name;
            this.Description = ClubIn.Description;
            this.Active = ClubIn.Active;
            this.MemberList = new Members(ClubIn.MemberList);
            this.President = new Member(ClubIn.President);
            this.AnnounceHistory = new Announcements(ClubIn.AnnounceHistory);
            this.EventList = new Events(ClubIn.EventList);
        }//end Club(Club)
        #endregion

        #region Setters and Getters
        public void SetName(String NameIn)
        {
            this.Name = NameIn;
        }

        public String GetName()
        {
            return this.Name;
        }

        public void SetDescription(String DescriptionIn)
        {
            this.Description = DescriptionIn;
        }

        public String GetDescription()
        {
            return this.Description;
        }

        public Boolean IsActive()
        {
            return this.Active;
        }

        public void SetActive(Boolean StatusIn)
        {
            this.Active = StatusIn;
        }


        public void SetMemberList(Members MembersIn)
        {
            this.MemberList = new Members(MembersIn);
        }

        public Members GetMemberList()
        {
            return this.MemberList;
        }

        public void SetPresident(Member MemberIn)
        {
            this.President = new Member(MemberIn);
        }

        public Member GetPresident()
        {
            return this.President;
        }

        public void SetAnnouncements(Announcements AnnouncementsIn)
        {
            this.AnnounceHistory = new Announcements(AnnouncementsIn);
        }

        public Announcements GetAnnouncements()
        {
            return this.AnnounceHistory;
        }

        public Events GetEvents()
        {
            return this.EventList;
        }
        #endregion

        public override string ToString()
        {
            return "Name: " + Name + " Description: " + Description + " Activation Status: " + Active + " Member List: " + MemberList
                + "President: " + President + " AnnouncementHistory: " + AnnounceHistory + " Events: " + EventList;
        }
    }
}
