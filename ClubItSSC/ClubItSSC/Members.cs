using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    public class Members
    {
        private List<Member> MemberList;

        #region Constructors
        public Members()
        {
            MemberList = new List<Member>();
        }

        public Members(Members MembersIn)
        {
            this.MemberList = MembersIn.CopyMembers();
        }
        #endregion

        #region Setters and Getters
        public void SetMemberList(List<Member> MembersIn)
        {

        }

        public List<Member> GetMemberList()
        {
            return this.MemberList;
        }

        #endregion

        /// <summary>
        /// Creates a deep copy of the members list in the Members container class
        /// </summary>
        /// <returns> A deep copy of the member list </returns>
        public List<Member> CopyMembers()
        {
            List<Member> tempMembers = new List<Member>(this.MemberList.Count);
            for (int iCount = 0; iCount < MemberList.Count; iCount++)
            {
                tempMembers.Add(this.MemberList[iCount]);
                
            }
            return tempMembers;
        }//end CopyMemberList(List<Member>)

        /// <summary>
        /// Performs a binary search on the members list 
        /// </summary>
        /// <param name="MemberIn"> The member that will be searched for </param>
        /// <returns> The index of the member object </returns>
        public int SearchMembers(Member MemberIn)
        {
           return MemberList.BinarySearch(MemberIn);
        }//end SearchMembers(Member)

        /// <summary>
        /// Performs a quick sort on the member list
        /// </summary>
        public void SortMembers()
        {
            this.MemberList.Sort();
        }//end SortMembers()
    }//end Members
}
