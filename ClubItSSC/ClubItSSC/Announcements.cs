using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    class Announcements
    {
        private List<Announcement> AnnouncementList;

        public Announcements(Announcements AnnouncementsIn)
        {
            this.AnnouncementList = AnnouncementsIn.CopyAnnouncements();
        }

        public void SetAnnouncements(List<Announcement> AnnouncementsIn)
        {

        }

        public List<Announcement> GetAnnouncements()
        {
            return this.AnnouncementList;
        }

        public List<Announcement> CopyAnnouncements()
        {
            List<Announcement> tempAnnouncements = new List<Announcement>(this.AnnouncementList.Count);
            for (int iCount = 0; iCount < this.AnnouncementList.Count; iCount++)
            {
                tempAnnouncements.Add(this.AnnouncementList[iCount]);
            }
            return tempAnnouncements;
        }//end CopyMemberList(List<Interests>)
    }
}
