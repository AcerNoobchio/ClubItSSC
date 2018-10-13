using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    class UserInterests
    {
        List<UserInterest> Interests;

        public UserInterests(UserInterests UserInterestsIn)
        {
            this.Interests = UserInterestsIn.CopyInterests();
        }

        public void SetUserInterests(List<UserInterest> InterestsIn)
        {
            
        
        }

        public List<UserInterest> GetUserInterests()
        {
            return this.Interests;
        }

        public List<UserInterest> CopyInterests()
        {
            List<UserInterest> tempInterests = new List<UserInterest>(this.Interests.Count);
            for (int iCount = 0; iCount < this.Interests.Count; iCount++)
            {
                tempInterests.Add(this.Interests[iCount]);
            }
            return tempInterests;
        }//end CopyMemberList(List<Interests>)
    }
}
