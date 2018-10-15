using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    class Announcements
    {
        private List<Announcement> AnnouncementList;

        #region Constructors

        public Announcements()
        {
            AnnouncementList = new List<Announcement>();
        }

        public Announcements(Announcements AnnouncementsIn)
        {
            this.AnnouncementList = AnnouncementsIn.CopyAnnouncements();
        }

        #endregion

        #region Setters and Getters

        public void SetAnnouncements(List<Announcement> AnnouncementsIn)
        {

        }

        public List<Announcement> GetAnnouncements()
        {
            return this.AnnouncementList;
        }

        #endregion

        /// <summary>
        /// Returns a deep copy of the list of announcements
        /// </summary>
        /// <returns> A copy of the announcement list </returns>
        public List<Announcement> CopyAnnouncements()
        {
            List<Announcement> tempAnnouncements = new List<Announcement>(this.AnnouncementList.Count);
            for (int iCount = 0; iCount < this.AnnouncementList.Count; iCount++)
            {
                tempAnnouncements.Add(this.AnnouncementList[iCount]);
            }
            return tempAnnouncements;
        }//end CopyMemberList(List<Interests>)
    }//end Announcements
}
