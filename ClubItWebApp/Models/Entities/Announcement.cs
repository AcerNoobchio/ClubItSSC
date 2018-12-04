using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubItWebApp.Models.Entities
{
    public class Announcement
    {
        String Headline;
        String Text;

        #region Constructors
        public Announcement()
        {
            this.Headline = "No Headline Specified";
            this.Text = "No Text Entered";
        }//end Announcement()

        public Announcement(String HeadlineIn, String TextIn)
        {
            this.Headline = HeadlineIn;
            this.Text = TextIn;
        }//end Announcement(String, String)

        public Announcement(Announcement AnnouncementIn)
        {
            this.Headline = AnnouncementIn.Headline;
            this.Text = AnnouncementIn.Text;
        }//end Announcement(Announcement)
        #endregion

        #region Setters and Getters
        public void SetHeadline(String HeadlineIn)
        {
            this.Headline = HeadlineIn;
        }

        public String GetHeadline()
        {
            return this.Headline;
        }

        public void SetText(String TextIn)
        {
            this.Text = TextIn;
        }

        public String GetText()
        {
            return this.Text;
        }
        #endregion
    }
}
