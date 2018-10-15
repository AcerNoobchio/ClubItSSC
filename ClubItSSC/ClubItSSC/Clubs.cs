using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    class Clubs
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
        }
    }//end Clubs
}
