using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    class Member
    {
        private String Name;
        private String ENumber;
        private UserInterests Interests;
        private UserType Type;

        #region constructors
        public Member()
        {
            Name = "";
            ENumber = "E00000000";      //Probably gonna get rid of it
            Interests = null;           //Replace this later, bad practice
            Type = UserType.StudentUser;
        }//end Member()

        /// <summary>
        /// The parameterized constructor for a member, used for generating new members from the gui
        /// </summary>
        /// <param name="NameIn"> The user's name </param>
        /// <param name="ENumberIn"> The user's ENumber </param>
        /// <param name="InterestsIn"> The User's interests </param>
        /// <param name="TypeIn"> The user Type - SuperAdmin/ClubAdmin/StudentUser </param>
        public Member(String NameIn, String ENumberIn, UserInterests InterestsIn, UserType TypeIn)
        {
            this.Name = NameIn;
            this.ENumber = ENumberIn;
            this.Interests = new UserInterests(InterestsIn);
            this.Type = TypeIn;
        }//end Member(String, String, UserInterests, UserType)

        public Member(Member MemberIn)
        {
            this.Name = MemberIn.Name;
            this.ENumber = MemberIn.ENumber;
            this.Interests = new UserInterests(MemberIn.Interests);
            Type = MemberIn.Type;
        }//end Member(Member)
        #endregion

        #region setters and getters
        public void setName(String NameIn)
        {
            this.Name = NameIn;
        }

        public String getName()
        {
            return this.Name;
        }

        public void setENumber(String ENumberIn)
        {
            this.ENumber = ENumberIn;
        }

        public String getENumber()
        {
            return this.ENumber;
        }

        public void setInterests(UserInterests InterestsIn)
        {
            this.Interests = InterestsIn;
        }

        public UserInterests getUserInterests()
        {
            return this.Interests;
        }

        public void setType(UserType TypeIn)
        {
            this.Type = TypeIn;
        }
        #endregion
    }//end Member
}
