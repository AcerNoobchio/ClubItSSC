using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    /// <summary>
    /// Collection class for Interests, contains the methods used to organize the User Interest List
    /// </summary>
    public class UserInterests
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

        /// <summary>
        /// Interests constructor that takes a single string and populates the list using the split method
        /// </summary>
        /// <param name="RawData"></param>
        public UserInterests(String RawData)
        {
            Interests = new List<UserInterest>();
            RawData.ToLower();  //Make sure it is all lowercase
            Split(RawData);
        }//end UserInterests(String)

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

        /// <summary>
        /// Splits the string into different interests based on delimeter
        /// </summary>
        public void Split(String strIn)
        {
            if (strIn != null)  //Make sure some goofball didn't pass a null string
            {
                char[] delim = { ',', ';', '.', };
                char[] whitespace = { ' ' };
                string[] NewStrings = strIn.Split(delim);
                for (int iCount = 0; iCount < NewStrings.Length; iCount++)
                {
                    this.Interests.Add(new UserInterest(NewStrings[iCount].TrimStart(whitespace)));     //Create new interest for each individual element in the string
                }
            }

        }//end Split()

        /// <summary>
        /// Removes Stop words, prepositions, and stems from each of the UserInterests
        /// </summary>
        public void Process()
        {
            for(int i = 0; i < Interests.Count; i++)
            {
                NLPUtil.RemoveStopWords(Interests[i]);
                NLPUtil.RemovePrepositions(Interests[i]);
                NLPUtil.RemoveProfanity(Interests[i]);
                NLPUtil.Stem(Interests[i]);
            }
        }//end Process()

        #region List Methods
        /// <summary>
        /// Performs a binary search on the Interests list
        /// </summary>
        /// <param name="InterestsIn"> The Interest that we're searching for </param>
        /// <returns> The indexed position of the Interests or a negative number if nothing found </returns>
        public int SearchInterests(UserInterest InterestIn)
        {
            return this.Interests.BinarySearch(InterestIn);
        }//end SearchInterests(Interests)

        /// <summary>
        /// Performs a quicksort on the Interests list
        /// </summary>
        public void SortInterests()
        {
            this.Interests.Sort();
        }//end SortInterests()

        public void Add(UserInterest InterestIn)
        {
            this.Interests.Add(InterestIn);
        }//end Add(UserInterest)

        public void Remove(UserInterest InterestIn)
        {
            this.Interests.Remove(InterestIn);
        }//end Remove(UserInterest)

        public void RemoveAt(int Index)
        {
            this.Interests.RemoveAt(Index);
        }//end RemoveAt(int)

        public override string ToString()
        {
            String str = "";
            for (int iCount = 0; iCount < this.Interests.Count; iCount++)
            {
                str += this.Interests[iCount];
                str += "\n\r";
            }
            return str;
        }//end ToString()
        #endregion
    }//end UserInterests
}
