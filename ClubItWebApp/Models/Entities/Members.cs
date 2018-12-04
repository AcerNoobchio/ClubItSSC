using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubItWebApp.Models.Entities
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

        public void Add(Member MemberIn)
        {
            this.MemberList.Add(MemberIn);
        }

        public void Remove(Member MemberIn)
        {
            this.MemberList.Remove(MemberIn);
        }

        public void RemoveAt(int Index)
        {
            this.MemberList.RemoveAt(Index);
        }

        public override string ToString()
        {
            String str = "";
            for (int iCount = 0; iCount < this.MemberList.Count; iCount++)
            {
                str += this.MemberList[iCount];
                str += "\n\r";
            }
            return str;
        }//end ToString()
    }
}
