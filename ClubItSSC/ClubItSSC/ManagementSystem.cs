using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    class ManagementSystem
    {
        private Member CurrentUser;     //The user that is currently logged in
        private Clubs SelectedClubs;    //The club that the management system is currently interacting with
        #region Setters and Getters
        public int setCurrentUser(Member UserIn)
        {
            int iValid = 0;
            if(UserIn != null)
            {
                this.CurrentUser = UserIn;
            }
            else
            {
                iValid = -1;
            }
            return iValid;
        }

        public Member getCurrentUser()
        {
            return CurrentUser;
        }

        public int setSelectedClubs(Clubs ClubsIn)
        {
            int iValid = 0;
            if(ClubsIn != null)
            {
                this.SelectedClubs = new Clubs(ClubsIn);
            }
            else
            {
                iValid = -1;
            }
            return iValid;
        }

        public Clubs getSelectedClubs()
        {
            return this.SelectedClubs;
        }
        #endregion

    }
}
