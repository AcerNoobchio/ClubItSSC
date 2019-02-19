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
        private Member CurrentUser;             //The user that is currently logged in
        private Members AllUsers;               //The List of all members, should be populated by the database
        private Clubs SelectedClubs;            //The club that the management system is currently interacting with
        private Clubs AllClubs;                 //The list of All clubs, should be populated by the database
        private Events MasterCalendar;          //the list of all events, should be populated by the database
        private AllInterests InterestFrequency; //The list of all interests and the frequency at which they occur
        private int ClubThreshold = 7;          //The threshold at which a new club is created
        private int field;

        #region Constructors
        public Manage()
        {
            CurrentUser = new Member();
            SelectedClubs = new Clubs();
            AllClubs = new Clubs();         //Maybe replace with reading from the database, Im not sure yet
            AllUsers = new Members();
            MasterCalendar = new Events();
            InterestFrequency = new AllInterests();
        }//end Manage()

        public Manage(Member CurrentUserIn, Clubs SelectedClubsIn, Clubs AllClubsIn, Members AllUsersIn, Events CalendarIn, AllInterests FrequencyIn)
        {
            this.CurrentUser = new Member(CurrentUserIn);
            this.SelectedClubs = new Clubs(SelectedClubsIn);
            this.AllClubs = new Clubs(AllClubsIn);
            this.AllUsers = new Members(AllUsersIn);
            this.MasterCalendar = new Events(CalendarIn);
            this.InterestFrequency = new AllInterests(FrequencyIn);
        }//end Manage(Member, Clubs, Clubs)

        public Manage(Manage ManageIn)
        {
            this.CurrentUser = new Member(ManageIn.CurrentUser);
            this.SelectedClubs = new Clubs(ManageIn.SelectedClubs);
            this.AllClubs = new Clubs(ManageIn.AllClubs);
            this.AllUsers = new Members(ManageIn.AllUsers);
            this.MasterCalendar = new Events(ManageIn.MasterCalendar);
            this.InterestFrequency = new AllInterests(ManageIn.InterestFrequency);
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

        public Events GetCalendar()
        {
            return this.MasterCalendar;
        }//end GetMasterCalendar()

        public AllInterests GetInterestFrequency()
        {
            return this.InterestFrequency;
        }//end GetInterestFrequency()

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
                AllUsers.SortMembers();     //Keep the list nice and tidy

                this.InterestFrequency.AddInterests(UserIn.GetUserInterests(), UserIn); //Add the user's interests to the table

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
                this.InterestFrequency.RemoveInterests(AllUsers.GetMemberList()[Index].GetUserInterests(), AllUsers.GetMemberList()[Index]); //Remove the user's old interests

                AllUsers.GetMemberList()[Index] = new Member(UserIn);
                AllUsers.SortMembers();         //Keep the list nice and tidy

                this.InterestFrequency.AddInterests(UserIn.GetUserInterests(), UserIn); //Add the user's new interests to the table

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
                this.InterestFrequency.RemoveInterests(AllUsers.GetMemberList()[Index].GetUserInterests(), AllUsers.GetMemberList()[Index]); //Remove the user's interests as well

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
                AllClubs.SortClubs();
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
                AllClubs.SortClubs();
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

        #region CRUD Event
        /// <summary>
        /// Allows a club admin or super admin to create an event
        /// </summary>
        /// <param name="EventIn"> the Event </param>
        /// <param name="ClubIndex"> The position of the club in the list of all clubs </param>
        /// <returns> A 1 if the user has insufficient privileges, a 0 otherwise </returns>
        public int CreateEvent(Event EventIn, int ClubIndex)
        {
            int iReturnCode = 0;
            if (CurrentUser.GetUserType().Equals(UserType.SuperAdmin) || CurrentUser.GetUserType().Equals(UserType.ClubAdmin))
            {
                AllClubs.GetClubs()[ClubIndex].GetEvents().GetEventList().Add(EventIn);
                AllClubs.GetClubs()[ClubIndex].GetEvents().GetEventList().Sort();                                           //Sort the club's event list for tidiness

                this.MasterCalendar.Add(EventIn);                                                                           //Update the master calendar when the event is created
                this.MasterCalendar.SortEvents();

                //This might be a good place to update the database
            }
            else
            {
                iReturnCode = 1; //Indicates insufficient privileges
            }

            return iReturnCode;
        }//end CreateEvent(Event, int)

        /// <summary>
        /// Allows a SuperAdmin or Club admin to edit an event
        /// </summary>
        /// <param name="EventIn"> The new event whose parameters will replace the old event </param>
        /// <param name="ClubIndex"> The index of the club being edited </param>
        /// <param name="EventIndex"> The index of the event being edited </param>
        /// <returns> A Return code that indicates the status of the operation </returns>
        public int EditEvent(Event EventIn, int ClubIndex, int EventIndex)
        {
            int iReturnCode = 0;
            if (CurrentUser.GetUserType().Equals(UserType.SuperAdmin) || CurrentUser.GetUserType().Equals(UserType.ClubAdmin))
            {
                int iMemberIndex = 0;
                int iEventIndex = 0;

                Members MembersToUpdate = new Members();
                Event OldEvent = AllClubs.GetClubs()[ClubIndex].GetEvents().GetEventList()[EventIndex];
                AllClubs.GetClubs()[ClubIndex].GetEvents().GetEventList()[EventIndex] = new Event(EventIn);
                MembersToUpdate = new Members(AllClubs.GetClubs()[ClubIndex].GetEvents().GetEventList()[EventIndex].GetInterest()); //Copy the user list from the event to the temp list

                this.MasterCalendar.GetEventList()[MasterCalendar.SearchEvents(OldEvent)] = new Event(EventIn);                 //Edit the event in the master calendar
                this.MasterCalendar.SortEvents();

                if (MembersToUpdate != null)                                                                                    //It is possible that the event exists but no user is interested
                {
                    for (int iCount = 0; iCount < MembersToUpdate.GetMemberList().Count; iCount++)                              //For each member interested in the event
                    {
                        iMemberIndex = AllUsers.SearchMembers(MembersToUpdate.GetMemberList()[iCount]);                         //Find the location of the member
                        AllUsers.GetMemberList()[iMemberIndex].GetEvents().SortEvents();                                        //Make the search more efficient, will probably replace this later
                        iEventIndex = AllUsers.GetMemberList()[iMemberIndex].GetEvents().SearchEvents(OldEvent);                //Find the location of the event in that user's Event list
                        AllUsers.GetMemberList()[iMemberIndex].GetEvents().GetEventList()[iEventIndex] = new Event(EventIn);    //Replace the user's copy of the event
                        AllUsers.GetMemberList()[iMemberIndex].GetEvents().SortEvents();                                        //Sort again because the title may have changed. 

                        if (MembersToUpdate.GetMemberList()[iCount] == this.CurrentUser)
                        {
                            SaveUser();
                        }
                    } 
                }

                AllClubs.GetClubs()[ClubIndex].GetEvents().GetEventList().Sort();                                           //Sort the club's event list for tidiness
                //This might be a good place to update the database
                //Need to update all user's Calendars
            }
            else
            {
                iReturnCode = 1; //Indicates insufficient privileges
            }

            return iReturnCode;
        }//end EditEvent(Event, int, int)

        /// <summary>
        /// Allows a SuperAdmin or Club admin to delete an event
        /// </summary>
        /// <param name="ClubIndex"> The index of the club to remove the event from </param>
        /// <param name="EventIndex"> The index of the event in the club's event list </param>
        /// <returns> A 0 if successful, or a 1 if unsuccessful </returns>
        public int DeleteEvent(int ClubIndex, int EventIndex)
        {
            int iReturnCode = 0;
            if (CurrentUser.GetUserType().Equals(UserType.SuperAdmin) || CurrentUser.GetUserType().Equals(UserType.ClubAdmin))
            {
                int iMemberIndex = 0;
                int iEventIndex = 0;

                Event OldEvent = AllClubs.GetClubs()[ClubIndex].GetEvents().GetEventList()[EventIndex];
                Members MembersToUpdate = new Members();
                MembersToUpdate = new Members(AllClubs.GetClubs()[ClubIndex].GetEvents().GetEventList()[EventIndex].GetInterest()); //Copy the user list from the event to the temp list
                AllClubs.GetClubs()[ClubIndex].GetEvents().GetEventList().RemoveAt(EventIndex);
                this.MasterCalendar.RemoveAt(MasterCalendar.SearchEvents(OldEvent));                                        //Remove the event in the master calendar

                for (int iCount = 0; iCount < MembersToUpdate.GetMemberList().Count; iCount++)                              //For each member interested in the event, need to remove Events from users too
                {
                    iMemberIndex = AllUsers.SearchMembers(MembersToUpdate.GetMemberList()[iCount]);                         //Find the location of the member
                    AllUsers.GetMemberList()[iMemberIndex].GetEvents().SortEvents();                                        //Make the search more efficient, will probably replace this later
                    iEventIndex = AllUsers.GetMemberList()[iMemberIndex].GetEvents().SearchEvents(OldEvent);                //Find the location of the event in that user's Event list
                    AllUsers.GetMemberList()[iMemberIndex].GetEvents().GetEventList().RemoveAt(iEventIndex);                //Remove the user's copy of the event

                    if(MembersToUpdate.GetMemberList()[iCount].Equals(this.CurrentUser))
                    {
                        SaveUser();
                    }
                }

                AllClubs.GetClubs()[ClubIndex].GetEvents().GetEventList().Sort();                                           //Sort the club's event list for tidiness
                //This might be a good place to update the database
                //Need to update all user's Calendars
            }
            else
            {
                iReturnCode = 1; //Indicates insufficient privileges
            }

            return iReturnCode;
        }//end EditEvent(Event, int, int)

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
                iReturnCode = 1;        //Indicate that the user was already in the club
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
                iReturnCode = 1;        //Indicate that the user cannot leave a club he/she is not in
            }

            return iReturnCode;
        }//end Unsubscribe(int)

        #endregion

        #region User-Event Interactions
        /// <summary>
        /// Allows the user to add an event to his/her event list, also adds the user to the event's interest list
        /// </summary>
        /// <param name="ClubIndex"> The index of the club which contains the event </param>
        /// <param name="EventIndex"> The index of the club's event list to be added </param>
        /// <returns> A 0 if the addition was successful or a 1 if the user was already in the club </returns>
        public int AddEvent(int ClubIndex, int EventIndex)
        {
            int iReturnCode = 0;
            int iMasterIndex = 0;
            Event OldEvent = AllClubs.GetClubs()[ClubIndex].GetEvents().GetEventList()[EventIndex];
            if (CurrentUser.GetEvents().SearchEvents(AllClubs.GetClubs()[ClubIndex].GetEvents().GetEventList()[EventIndex]) < 0) //If the user does not already have the event added
            {
                OldEvent.GetInterest().GetMemberList().Add(this.CurrentUser);      //Add the user to the event in question
                OldEvent.GetInterest().SortMembers();                              //Keep the member list nice and tidy

                iMasterIndex = MasterCalendar.SearchEvents(OldEvent);
                this.MasterCalendar.GetEventList()[iMasterIndex].GetInterest().Add(this.CurrentUser);    //Add the user to the event in the master calendar
                this.MasterCalendar.GetEventList()[iMasterIndex].GetInterest().SortMembers();

                CurrentUser.GetEvents().GetEventList().Add(new Event(AllClubs.GetClubs()[ClubIndex].GetEvents().GetEventList()[EventIndex]));   //Add the event to the user's event list
                CurrentUser.GetEvents().SortEvents();                                                                                           //Keep the user's event list nice and tidy
            }
            else
            {
                iReturnCode = 1;        //Indicate that the user cannot add a club that has already been added
            }
            UpdateUser();
            return iReturnCode;
        }//end AddEvent(int, int)

        /// <summary>
        /// Allows the user to remove an event from his/her event list, also removes the user from the event's interest list
        /// </summary>
        /// <param name="ClubIndex"> The index of the club to which the event belongs </param>
        /// <param name="EventIndex"> The index of the event to be removed </param>
        /// <returns> A 0 if the addition was successful or a 1 if the event was never there </returns>
        public int RemoveEvent(int ClubIndex, int EventIndex)
        {
            int iReturnCode = 0;
            Event OldEvent = AllClubs.GetClubs()[ClubIndex].GetEvents().GetEventList()[EventIndex];
            int iSearchResult = CurrentUser.GetEvents().SearchEvents(OldEvent);
            if (iSearchResult >= 0) //If the user already has the event added
            {
                OldEvent.GetInterest().GetMemberList().Remove(this.CurrentUser);                 //Remove the user from the event in question
                CurrentUser.GetEvents().GetEventList().RemoveAt(iSearchResult);                  //Remove the event from the user's event list

                iSearchResult = this.MasterCalendar.SearchEvents(OldEvent);                     //find the event in the Master Calendar
                this.MasterCalendar.GetEventList()[iSearchResult].GetInterest().GetMemberList().Remove(this.CurrentUser);
            }
            else
            {
                iReturnCode = 1;        //Indicate that the user cannot remove a non existant club
            }
            UpdateUser();
            return iReturnCode;
        }//end AddEvent(int, int)



        #endregion

        #region Frequency Table Methods

        /// <summary>
        /// Finds the number of clubs at the new club creation threshold 
        /// </summary>
        /// <returns> A List of interests at the threshold </returns>
        public UserInterests GetInterestsAtThreshold()
        {
            return this.InterestFrequency.GetFrequencyKeys(this.ClubThreshold);
        }//end GetInterestsAtThreshold()

        /// <summary>
        /// Determines whether or not there is sufficient interest to generate any new clubs 
        /// </summary>
        /// <returns> true if there are interests at the threshold, false otherwise </returns>
        public bool NewClubs()
        {
            return (this.InterestFrequency.GetFrequencyKeys(this.ClubThreshold).GetUserInterests().Count > 0);
        }//end NewClubs()

        /// <summary>
        /// Generates a print out of a single club that could be created and the users that would comprise it
        /// </summary>
        /// <param name="InterestIn"> the interest that the club would be based on </param>
        /// <returns> A notification in list format </returns>
        public String GenerateClubNotification(UserInterest InterestIn)
        {
            String strToReturn = "There is sufficient interest to create a " + InterestIn + " club with the following members:";
            for(int i = 0; i < this.InterestFrequency.GetUserValues(InterestIn).GetMemberList().Count; i++)
            {
                strToReturn += "\n" + InterestFrequency.GetUserValues(InterestIn).GetMemberList()[i].GetName();
                strToReturn += " - " + InterestFrequency.GetUserValues(InterestIn).GetMemberList()[i].GetEmail();
            }

            return strToReturn;
        }//end GenerateClubNotification()

        /// <summary>
        /// Generates a print out of all of the clubs that have sufficient interest to be created and the users that would comprise them
        /// </summary>
        /// <returns> A notifiation in list format </returns>
        public String GenerateClubNotifications()
        {
            UserInterests NewInterests = GetInterestsAtThreshold();
            int iNewClubs = NewInterests.GetUserInterests().Count;
            String strToReturn = iNewClubs + " new clubs can be formed\n";
            for(int i = 0; i < iNewClubs; i++)
            {
                strToReturn += GenerateClubNotification(NewInterests.GetUserInterests()[i]);
            }
            return strToReturn;
        }//end GenerateClubNotiifications


        #endregion

        /// <summary>
        /// Saves the changes to this user to the list of all users
        /// </summary>
        public void UpdateUser()
        {
            int iUserPos = 0;
            iUserPos = this.GetAllUsers().SearchMembers(this.CurrentUser);
            this.AllUsers.GetMemberList()[iUserPos] = new Member(this.CurrentUser);
        }//end UpdateUser()

        /// <summary>
        /// Saves from the List of all users to the current user
        /// </summary>
        public void SaveUser()
        {
            int iUserPos = 0;
            iUserPos = this.GetAllUsers().SearchMembers(this.CurrentUser);
            this.CurrentUser = new Member(this.GetAllUsers().GetMemberList()[iUserPos]);
        }//end SaveUser()

    }//end Manage
}
