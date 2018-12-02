using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    public class IndWord : IEquatable<IndWord>, IComparable<IndWord>
    {

        public String strWord;
        /// <summary>
        /// The property contains a string which represents a distinct word from the text file
        /// </summary>
        /// <value> The value passed to become the word, is converted to lowercase immediately </value>
        public String Word
        {
            get { return strWord; }
            set { strWord = value.ToLower(); }
        }//end Word

        /// <summary>
        /// Default constructor, used mainly for testing purposes and to tell the user if a IndWord class has been setup and not used
        /// </summary>
        public IndWord()
        {
            strWord = "None Entered";

        }//end IndWord()

        /// <summary>
        /// Parameterized constructor providing the user with the ability to create new words and fill them at the same time
        /// </summary>
        /// <param name="WordIn"> The string that will be kept as the distinct word's actual text representation </param>
        public IndWord(String WordIn)
        {
            if (WordIn.Length > 0)
            {
                strWord = WordIn.ToLower();
            }
        }//end IndWord(String)

        /// <summary>
        /// Allows one to see if one word equals another using the actual strings represented by the word objects
        /// </summary>
        /// <param name="W"> The word that is to be compared to the intance calling this method </param>
        /// <returns> T/F depending upon whether the strings are equal </returns>

        public bool Equals(IndWord W)
        {
            return (this.strWord.Equals(W.strWord));           //Return the output of the string comparison
        }//end IEquatable(IndWord)

        /// <summary>
        /// Allows one to compare a word to an object on the basis of equality
        /// </summary>
        /// <param name="obj"> The object being compared to a word </param>
        /// <returns> t/f based on whether the object equals the word </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)                     //If the object is null
            {
                return base.Equals(obj);
            }

            if (!(obj is IndWord))     //If the object isn't a distinct word
            {
                throw new ArgumentException("Parameter is not a distinct word");
            }


            return Equals(obj as IndWord);  //If the object is workable



        }//end Equals(Obj)

        /// <summary>
        /// Returns a hash code based on the string used for comparisons instead of the object
        /// </summary>
        /// <returns> A huge number representing the unique identity of this string </returns>
        public override int GetHashCode()
        {
            return strWord.GetHashCode();
        }//end GetHashCode()

        /// <summary>
        /// Compares two IndWords based on their string representations
        /// </summary>
        /// <param name="WIn"> The IndWord object that we are comparing to the intance calling the method </param>
        /// <returns> A number greater than 0 if the foreign object comes first, less than zero if after, or 0 if equal </returns>
        public int CompareTo(IndWord WIn)
        {
            return strWord.CompareTo(WIn.strWord);
        }//end CompareTo(IndWord)

        public String GetEnding(int NumPlaces)
        {
            String strFinal = "";
            if (NumPlaces < this.strWord.Length)
            {
                char[] NomBreakdown = this.strWord.ToCharArray();

                //for (int iCount = 0; iCount < NumPlaces; iCount++)
                for (int iCount = NumPlaces -1; iCount >= 0; iCount--)
                {
                    strFinal += NomBreakdown[this.strWord.Length - (iCount + 1)].ToString();
                }

            }

            return strFinal;
        }//end GetEnding

    }//end IndWord
}
