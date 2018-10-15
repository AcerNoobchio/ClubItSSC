using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    /// <summary>
    /// This is the system which will manage all user interactions with the club - this is also where I think most of the database stuff will happen, though Im not sure
    /// </summary>
    class Manage
    {
        private Member CurrentUser;     //The user that is currently logged in
        private Clubs SelectedClubs;    //The club that the management system is currently interacting with
        private Clubs AllClubs;         //The list of All clubs, should be populated by the database

        #region Constructors
        public Manage()
        {
            CurrentUser = new Member();
            SelectedClubs = new Clubs();
            AllClubs = new Clubs();         //Maybe replace with reading from the database, Im not sure yet
        }//end Manage()

        public Manage(Member CurrentUserIn, Clubs SelectedClubsIn, Clubs AllClubsIn)
        {
            this.CurrentUser = new Member(CurrentUserIn);
            this.SelectedClubs = new Clubs(SelectedClubsIn);
            this.AllClubs = new Clubs(AllClubsIn);
        }//end Manage(Member, Clubs, Clubs)

        public Manage(Manage ManageIn)
        {
            this.CurrentUser = new Member(ManageIn.CurrentUser);
            this.SelectedClubs = new Clubs(ManageIn.SelectedClubs);
            this.AllClubs = new Clubs(ManageIn.AllClubs);
        }//end Manage(Manage)
        #endregion


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

        public void CreateClub(Club ClubIn)
        {
            AllClubs.GetClubs().Add(new Club(ClubIn));
        }//end CreateClub(Club)
    }//end Manage
}
