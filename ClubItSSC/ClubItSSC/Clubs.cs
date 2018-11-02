using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    public class Clubs
    {
        private List<Club> SelectedClubs;

        #region Constructors
        public Clubs()
        {
            SelectedClubs = new List<Club>();
        }

        public Clubs(Clubs ClubsIn)
        {
            this.SelectedClubs = ClubsIn.CopyClubs();
        }

        #endregion

        #region Setters and Getters

        public List<Club> GetClubs()
        {
            return this.SelectedClubs;
        }//end GetClubs()

        #endregion

        /// <summary>
        /// Makes a deep copy  of the Selected Clubs attribute
        /// </summary>
        /// <returns> A Copy of the list of clubs </returns>
        public List<Club> CopyClubs()
        {
            List<Club> tempClub = new List<Club>(this.SelectedClubs.Count);
            for(int iCount = 0; iCount < SelectedClubs.Count; iCount++)
            {
                tempClub.Add(this.SelectedClubs[iCount]);
            }
            return tempClub;
        }//end CopyClubs()

        /// <summary>
        /// Performs a binary search on the club list
        /// </summary>
        /// <param name="ClubIn"> The club that we're searching for </param>
        /// <returns> The indexed position of the Club or a negative number if nothing found </returns>
        public int SearchClubs(Club ClubIn)
        {
            return this.SelectedClubs.BinarySearch(ClubIn);
        }//end SearchClubs(Club)

        /// <summary>
        /// Performs a quicksort on the Club list
        /// </summary>
        public void SortClubs()
        {
            this.SelectedClubs.Sort();
        }//end SortClubs()

    }//end Clubs
}
