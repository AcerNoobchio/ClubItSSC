using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    /// <summary>
    /// Holds a Member object which represents a user in the system or a member of a club
    /// </summary>
    public class Member : IComparable<Member>, IEquatable<Member>
    {
        private String Name;
        private String Email;
        private UserInterests Interests;
        private UserType Type;                      //ClubAdmin, SuperAdmin, StudentUser
        private EventInterest EventInterest;        //To be used by the event class in determining the user's interest in that specific event 
        private Events EventList; 

        /// <summary>
        /// Compares two members on the basis of full name
        /// </summary>
        /// <param name="MemberIn"> The member that this member is being compared to </param>
        /// <returns> greater than 0 if this member is "greater" than the other less than 0 if this member is les than </returns>
        public int CompareTo(Member MemberIn)
        {
            return this.Name.CompareTo(MemberIn.Name);
        }//end CompareTo(Member)


        /// <summary>
        /// Compares two event objects based on time and title
        /// </summary>
        /// <param name="other"> The event being compared to the calling event </param>
        /// <returns> True if equal, false if not </returns>
        public bool Equals(Member other)
        {
            Boolean equals = false;
            if (this.Email == other.Email)
            {
                equals = true;
            }
            else
            {
                equals = false;
            }
            return equals;
        }//endIEquatable<Event>.Equals(Event)

        
        public override bool Equals(object MemberIn)
        {
            if (MemberIn == null)
            {
                return base.Equals(MemberIn);
            }
            if (!(MemberIn is Member))
            {
                throw new ArgumentException("Parameter is not a Member");
            }
            else
            {
                return Equals (MemberIn as Member);
            }
        }//end Equals(Object)
        
        public override int GetHashCode()
        {
            return this.Email.GetHashCode();
        }//end GetHashCode()

        #region constructors
        public Member()
        {
            Name = "";
            Email = "@etsu.edu";                       //Probably gonna get rid of it
            Interests = new UserInterests();           //Replace this later, bad practice
            Type = UserType.StudentUser;
            EventInterest = EventInterest.NotGoing;
            EventList = new Events();
        }//end Member()

        /// <summary>
        /// The parameterized constructor for a member, used for generating new members from the gui
        /// </summary>
        /// <param name="NameIn"> The user's name </param>
        /// <param name="ENumberIn"> The user's ENumber </param>
        /// <param name="InterestsIn"> The User's interests </param>
        /// <param name="TypeIn"> The user Type - SuperAdmin/ClubAdmin/StudentUser </param>
        public Member(String NameIn, String ENumberIn, UserInterests InterestsIn, UserType TypeIn, Events EventsIn)
        {
            this.Name = NameIn;
            this.Email = ENumberIn;
            this.Interests = new UserInterests(InterestsIn);
            this.Type = TypeIn;
            this.EventList = new Events(EventsIn);
            EventInterest = EventInterest.NotGoing;
        }//end Member(String, String, UserInterests, UserType)

        public Member(String NameIn, String ENumberIn, UserInterests InterestsIn, UserType TypeIn, EventInterest InterestIn, Events EventsIn)
        {
            this.Name = NameIn;
            this.Email = ENumberIn;
            this.Interests = new UserInterests(InterestsIn);
            this.Type = TypeIn;
            this.EventList = new Events(EventsIn);
            this.EventInterest = InterestIn;
        }//end Member(String, String, UserInterests, UserType)

        public Member(Member MemberIn)
        {
            this.Name = MemberIn.Name;
            this.Email = MemberIn.Email;
            this.Interests = new UserInterests(MemberIn.Interests);
            Type = MemberIn.Type;
            this.EventInterest = MemberIn.EventInterest;
            this.EventList = new Events(MemberIn.GetEvents());
            
        }//end Member(Member)
        #endregion

        #region setters and getters

        public void SetUserType(UserType TypeIn)
        {
            this.Type = TypeIn;
        }

        public void GetName(String NameIn)
        {
            this.Name = NameIn;
        }

        public String GetName()
        {
            return this.Name;
        }

        public void SetEmail(String EmailIn)
        {
            this.Email = EmailIn;
        }

        public String GetEmail()
        {
            return this.Email;
        }

        public void GetInterests(UserInterests InterestsIn)
        {
            this.Interests = InterestsIn;
        }

        public UserInterests GetUserInterests()
        {
            return this.Interests;
        }

        public EventInterest GetEventInterest()
        {
            return this.EventInterest;
        }

        public Events GetEvents()
        {
            return this.EventList;
        }

        public UserType GetUserType()
        {
            return this.Type;
        }
        #endregion

        public override string ToString()
        {
            return "Member Name: " + Name + " Email: " + Email + " Interests: " + Interests + " User Type: " + Type + "Event List: " + this.EventList;
        }
    }//end Member
}
