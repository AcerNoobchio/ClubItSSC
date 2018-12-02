using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    public class UserInterest : IEquatable<UserInterest>, IComparable<UserInterest>
    {
        private String Name;
        private List<IndWord> WordList; //can have multiple words to describe an interest

        /// <summary>
        /// Compares two members on the basis of full name
        /// </summary>
        /// <param name="MemberIn"> The member that this member is being compared to </param>
        /// <returns> greater than 0 if this member is "greater" than the other less than 0 if this member is les than </returns>
        public int CompareTo(UserInterest InterestIn)
        {
            return this.Name.CompareTo(InterestIn.Name);
        }//end CompareTo(Member)


        /// <summary>
        /// Compares two event objects based on time and title
        /// </summary>
        /// <param name="other"> The event being compared to the calling event </param>
        /// <returns> True if equal, false if not </returns>
        public bool Equals(UserInterest other)
        {
            Boolean equals = false;
            if (this.Name == other.Name)
            {
                equals = true;
            }
            else
            {
                equals = false;
            }
            return equals;
        }//endIEquatable<Event>.Equals(Event)


        public override bool Equals(object InterestIn)
        {
            if (InterestIn == null)
            {
                return base.Equals(InterestIn);
            }
            if (!(InterestIn is UserInterest))
            {
                throw new ArgumentException("Parameter is not a user Interest");
            }
            else
            {
                return Equals(InterestIn as UserInterest);
            }
        }//end Equals(Object)

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }//end GetHashCode()

        #region Constructors
        public UserInterest()
        {
            Name = "Not Entered";
        }//end UserInterest()

        public UserInterest(String NameIn)
        {
            Name = NameIn.ToLower();
            Split();
        }//end UserInterest(String, String)

        public UserInterest(UserInterest InterestIn)
        {
            this.Name = InterestIn.Name.ToLower();
            Split();
        }//end UserInterest(UserInterest)
        #endregion

        #region Setters and Getters
        public void SetName(String NameIn)
        {
            this.Name = NameIn.ToLower();
            Split();
        }

        public String GetName()
        {
            return this.Name;
        }

        public List<IndWord> GetWordList()
        {
            return this.WordList;
        }
        #endregion

        #region Mutator Methods
        /// <summary>
        /// Splits the user interest base text into each individual word
        /// </summary>
        public void Split()
        {
            if (WordList != null)
            {
                this.WordList.Clear();                                      //Ensure that there is no duplication
            }
            else
            {
                WordList = new List<IndWord>();
            }

            char[] delim = { ' ','\t','|' };
            string[] NewStrings = this.Name.Split(delim);
            for(int iCount = 0; iCount < NewStrings.Length; iCount++)
            {
                this.WordList.Add(new IndWord(NewStrings[iCount]));     //Create new word for each individual element in the interest
            }
        }//end Split()

        /// <summary>
        /// Combines the split words back into the full text, used after some processing on the word list e.g. stemming
        /// </summary>
        public void Combine()
        {
            this.Name = ""; //reset interest text
            for(int iCount = 0; iCount < WordList.Count; iCount++)
            {
                Name += WordList[iCount].strWord;       //Add the words to the new interest
                if (iCount != WordList.Count - 1)
                {
                    Name += " ";                        //Add a space between each word
                }
            }
            Split();                                    //Keep the word list up-to-date
        }//end Combine()

        /// <summary>
        /// Gets the final n letters of the given interest
        /// </summary>
        /// <param name="NumPlaces"> The number of letters in the ending </param>
        /// <returns> The substring given </returns>
        public String GetEnding(int NumPlaces)
        {
            String strFinal = "";
            if (NumPlaces < this.Name.Length)
            {
                char[] NomBreakdown = this.Name.ToCharArray();

                for (int iCount = 0; iCount < NumPlaces; iCount++)
                {
                    strFinal += NomBreakdown[this.Name.Length - (iCount + 1)].ToString();
                }

            }

            return strFinal;
        }//end GetEnding()
        #endregion

        /// <summary>
        /// Print out the whole text
        /// </summary>
        /// <returns> The string representation of the User Interest </returns>
        public override string ToString()
        {
            return this.Name;
        }//end ToString()

    }//end UserInterest
}
