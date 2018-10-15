using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    class Members
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
        public void setMemberList(List<Member> MembersIn)
        {

        }

        public List<Member> getMemberList()
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
    }//end Members
}
