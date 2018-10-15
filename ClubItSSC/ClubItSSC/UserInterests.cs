using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    /// <summary>
    /// Collection class for Interests, contains the methods used to organize the User Interest List
    /// </summary>
    class UserInterests
    {
        List<UserInterest> Interests;

        #region Constructors
        public UserInterests()
        {
            Interests = new List<UserInterest>(); 
        }

        public UserInterests(UserInterests UserInterestsIn)
        {
            this.Interests = UserInterestsIn.CopyInterests();
        }

        #endregion

        #region Setters and Getters
        public void SetUserInterests(List<UserInterest> InterestsIn)
        {
            
        
        }

        public List<UserInterest> GetUserInterests()
        {
            return this.Interests;
        }

        #endregion

        public List<UserInterest> CopyInterests()
        {
            List<UserInterest> tempInterests = new List<UserInterest>(this.Interests.Count);
            for (int iCount = 0; iCount < this.Interests.Count; iCount++)
            {
                tempInterests.Add(this.Interests[iCount]);
            }
            return tempInterests;
        }//end CopyMemberList(List<Interests>)
    }//end UserInterests
}
