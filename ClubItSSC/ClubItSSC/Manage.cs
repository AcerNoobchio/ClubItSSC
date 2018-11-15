using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    /// <summary>
    /// This is the system which will manage all user interactions with the club - this is also where I think most of the database stuff will happen, though Im not sure
    /// </summary>
    public class Manage
    {
        private Member CurrentUser;     //The user that is currently logged in
        private Members AllUsers;       //The List of all members, should be populated by the database
        private Clubs SelectedClubs;    //The club that the management system is currently interacting with
        private Clubs AllClubs;         //The list of All clubs, should be populated by the database

        #region Constructors
        public Manage()
        {
            CurrentUser = new Member();
            SelectedClubs = new Clubs();
            AllClubs = new Clubs();         //Maybe replace with reading from the database, Im not sure yet
            AllUsers = new Members();
        }//end Manage()

        public Manage(Member CurrentUserIn, Clubs SelectedClubsIn, Clubs AllClubsIn, Members AllUsersIn)
        {
            this.CurrentUser = new Member(CurrentUserIn);
            this.SelectedClubs = new Clubs(SelectedClubsIn);
            this.AllClubs = new Clubs(AllClubsIn);
            this.AllUsers = new Members(AllUsersIn);
        }//end Manage(Member, Clubs, Clubs)

        public Manage(Manage ManageIn)
        {
            this.CurrentUser = new Member(ManageIn.CurrentUser);
            this.SelectedClubs = new Clubs(ManageIn.SelectedClubs);
            this.AllClubs = new Clubs(ManageIn.AllClubs);
            this.AllUsers = new Members(ManageIn.AllUsers);
        }//end Manage(Manage)
        #endregion


        #region Setters and Getters
        public int SetCurrentUser(Member UserIn)
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
        }//end SetCurrentUser(Member)

        public Member GetCurrentUser()
        {
            return CurrentUser;
        }//end GetCurrentUser()

        public int SetAllUsers(Members UsersIn)
        {
            int iValid = 0;
            if(UsersIn != null)
            {
                this.AllUsers = new Members(UsersIn);
            }
            else
            {
                iValid = -1;
            }
            return iValid;
        }//end SetAllUsers(Members)

        public Members GetAllUsers()
        {
            return this.AllUsers;
        }//end GetAllUsers()

        public int SetSelectedClubs(Clubs ClubsIn)
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
        }//end SetSelectedClubs(Clubs)

        public Clubs GetSelectedClubs()
        {
            return this.SelectedClubs;
        }//end GetSelectedClubs()

        public int SetAllClubs(Clubs ClubsIn)
        {
            int iValid = 0;
            if (ClubsIn != null)
            {
                this.AllClubs = new Clubs(ClubsIn);
            }
            else
            {
                iValid = -1;
            }
            return iValid;
        }//end SetAllClubs(Clubs)

        public Clubs GetAllClubs()
        {
            return this.AllClubs;
        }//end GetAllClubs()

        #endregion


        #region CRUD Student User

        /// <summary>
        /// Allows the super admin to create a user, will likely be automated if given access to ETSU database
        /// </summary>
        /// <param name="UserIn"> The User Object that will be filled via the gui </param>
        /// <returns> A Return code that indicates the status of the operation </returns>
        public int CreateUser(Member UserIn)
        {
            int iReturnCode = 0;

            if (CurrentUser.GetUserType().Equals(UserType.SuperAdmin))
            {
                AllUsers.GetMemberList().Add(new Member(UserIn));
                //Sort Method placeholder
                //This might be a good place to update the database
            }
            else
            {
                iReturnCode = 1; //Indicates insufficient privileges
            }

            return iReturnCode;
        }//end CreateClub(Club)


        /// <summary>
        /// Allows the super admin to edit a user
        /// </summary>
        /// <param name="UserIn"> The user object that will be edited and passed here via the gui </param>
        /// <param name="Index"> The index of the user object in the entire user List </param>
        /// <returns> A Return code that indicates the status of the operation </returns>
        public int EditUser(Member UserIn, int Index)
        {
            int iReturnCode = 0;
            if (CurrentUser.GetUserType().Equals(UserType.SuperAdmin))
            {
                AllUsers.GetMemberList()[Index] = new Member(UserIn);
                //Sort the All Users List
                //Might be a good place for a database update
            }
            else
            {
                iReturnCode = 1; //Indicates insufficient privileges
            }

            return iReturnCode;
        }//end EditUser(Member, int)

        /// <summary>
        /// Allows the super admin to remove a user
        /// </summary>
        /// <param name="Index"> The index of the AllUser list that is being removed </param>
        /// <returns> A Return code that indicates the status of the operation </returns>
        public int RemoveUser(int Index)
        {
            int iReturnCode = 0;

            if (CurrentUser.GetUserType().Equals(UserType.SuperAdmin))
            {
                AllUsers.GetMemberList().RemoveAt(Index);
                //Sorting is likely not necessary here
                //Probably want to update the database here
            }
            else
            {
                iReturnCode = 1; //Indicates insufficient privileges
            }

            return iReturnCode;
        }//end RemoveClub(int)


        #endregion


        #region CRUD Club
        /// <summary>
        /// Creates a Club based on information on the gui page
        /// </summary>
        /// <param name="ClubIn"> The club object filled out by the gui </param>
        /// <returns> A Return code that indicates the status of the operation </returns>
        public int CreateClub(Club ClubIn)
        {
            int iReturnCode = 0;
            if(CurrentUser.GetUserType().Equals(UserType.SuperAdmin))
            {
                AllClubs.GetClubs().Add(new Club(ClubIn));
                //Sort Method placeholder
                //This might be a good place to update the database
            }
            else
            {
                iReturnCode = 1; //Indicates insufficient privileges
            }

            return iReturnCode;
        }//end CreateClub(Club)


        /// <summary>
        /// Allows the Super Admin to edit an existing club
        /// </summary>
        /// <param name="ClubIn"> The club object filled out by the gui </param>
        /// <param name="Index"> The index of the AllClubs array that is being edited </param>
        /// <returns> A Return code that indicates the status of the operation </returns>
        public int EditClub(Club ClubIn, int Index)
        {
            int iReturnCode = 0;
            if (CurrentUser.GetUserType().Equals(UserType.SuperAdmin))
            {
                AllClubs.GetClubs()[Index] = new Club(ClubIn);
                //Sort the All Clubs
                //Might be a good place for a database update
            }
            else
            {
                iReturnCode = 1; //Indicates insufficient privileges
            }

            return iReturnCode;
        }//end EditClub(ClubIn, Index)

        /// <summary>
        /// Allows the Super Admin to remove an existing club
        /// </summary>
        /// <param name="Index"> The index of the AllClubs list that is being removed </param>
        /// <returns> A Return code that indicates the status of the operation </returns>
        public int RemoveClub(int Index)
        {
            int iReturnCode = 0;

            if(CurrentUser.GetUserType().Equals(UserType.SuperAdmin))
            {
                AllClubs.GetClubs().RemoveAt(Index);
                //Sorting is likely not necessary here
                //Probably want to update the database here
            }
            else
            {
                iReturnCode = 1; //Indicates insufficient privileges
            }

            return iReturnCode;
        }//end RemoveClub(int)
        #endregion


        #region Student-Club Interactions

        /// <summary>
        /// Allows the current user to subscribe to a club
        /// </summary>
        /// <param name="Index"> The index of the club in the list of all clubs </param>
        /// <returns> A Return code that indicates the status of the operation </returns>
        public int Subscribe(int Index)
        {
            int iReturnCode = 0;
            if(AllClubs.GetClubs()[Index].GetMemberList().GetMemberList().BinarySearch(this.CurrentUser) < 0)   //If the User is not in the club
            {
                AllClubs.GetClubs()[Index].GetMemberList().GetMemberList().Add(this.CurrentUser);               //Add the user to the club
            }
            else
            {
                iReturnCode = 2;        //Indicate that the user was already in the club
            }
            return iReturnCode;
        }//end Subscribe(int)

        /// <summary>
        /// Allows the current user to unsubscribe from a club
        /// </summary>
        /// <param name="Index"> The index of the club in the list of all clubs </param>
        /// <returns> A Return code that indicates the status of the operation </returns>
        public int Unsubscribe(int Index)
        {
            int iReturnCode = 0;
            if (AllClubs.GetClubs()[Index].GetMemberList().GetMemberList().BinarySearch(this.CurrentUser) >= 0)   //If the User is in the club
            {
                AllClubs.GetClubs()[Index].GetMemberList().GetMemberList().Remove(this.CurrentUser);             //Remove the user
            }
            else
            {
                iReturnCode = 2;        //Indicate that the user cannot leave a club he/she is not in
            }

            return iReturnCode;
        }//end Unsubscribe(int)

        #endregion

    }//end Manage
}
