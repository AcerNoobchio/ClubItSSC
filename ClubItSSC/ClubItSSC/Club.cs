using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    class Club
    {
        private String Name;
        private String Description;
        private Boolean Active;
        private Members MemberList;
        private Member President;
        private Announcements AnnounceHistory;
        private Events EventList;

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

        public Announcements getAnnouncements()
        {
            return this.AnnounceHistory;
        }
        #endregion

    }
}
