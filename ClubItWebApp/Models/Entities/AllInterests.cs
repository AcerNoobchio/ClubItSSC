using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubItWebApp.Models.Entities
{
    public class AllInterests
    {
        /// <summary>
        /// An Interest-Frequency table; Key - Interest:UserInterest, Value - frequency:int
        /// </summary>
        Dictionary<UserInterest, Int32> Interests;

        public AllInterests()
        {
            Interests = new Dictionary<UserInterest, int>();
        }//end AllInterests()

        public AllInterests(AllInterests matrixIn)
        {
            this.Interests = new Dictionary<UserInterest, int>(matrixIn.Interests);
        }//end AllInterests(AllInterests)

        /// <summary>
        /// Adds a list of interests to the dictionary, see AddInterest for more detail
        /// </summary>
        /// <param name="InterestsIn"> The list of interests to add </param>
        public void AddInterests(UserInterests InterestsIn)
        {
            for (int i = 0; i < InterestsIn.GetUserInterests().Count; i++)
            {
                AddInterest(InterestsIn.GetUserInterests()[i]);
            }
        }//end AddInterests(UserInterests)

        /// <summary>
        /// Adds a single interest to the dictionary, if the interest already exists inc the key, if not, add it to the dictionary
        /// </summary>
        /// <param name="InterestIn"> The interest to search for </param>
        public void AddInterest(UserInterest InterestIn)
        {
            if (Interests.ContainsKey(InterestIn))
            {
                Interests[InterestIn]++;
            }
            else
            {
                Interests.Add(InterestIn, 1);
            }
        }//end AddInterest(InterestIn)

        /// <summary>
        /// Removes a list of interests from the dictionary, for more details, see RemoveInterest
        /// </summary>
        /// <param name="InterestsIn"> the interest to search for </param>
        public void RemoveInterests(UserInterests InterestsIn)
        {
            for (int i = 0; i < InterestsIn.GetUserInterests().Count; i++)
            {
                RemoveInterest(InterestsIn.GetUserInterests()[i]);
            }
        }//end RemoveInterests(UserInterests)

        /// <summary>
        /// Removes a single interest from the list, works by deducting the amount of occurances, if that number becomes zero, remove the interest entirely
        /// </summary>
        /// <param name="InterestIn"> the interest to search for </param>
        public void RemoveInterest(UserInterest InterestIn)
        {
            if (Interests.ContainsKey(InterestIn))
            {
                Interests[InterestIn]--;
                if (Interests[InterestIn] == 0)
                {
                    Interests.Remove(InterestIn);
                }
            }
        }//end RemoveInterest(UserInterest)

        public int GetValue(UserInterest InterestIn)
        {
            return Interests[InterestIn];
        }//end GetKey(UserInterest)

        /// <summary>
        /// Given a value, returns all of the keys with that value
        /// </summary>
        /// <param name="ValueIn"> The integer value to search for </param>
        /// <returns> A UserInterests object that contains a list of all interests found with the passed count value </returns>
        public UserInterests GetKeys(int ValueIn)
        {
            UserInterests interests = new UserInterests();
            foreach (KeyValuePair<UserInterest, int> count in this.Interests)
            {
                if (count.Value == ValueIn)
                {
                    interests.Add(count.Key);
                }
            }
            return interests;
        }//end GetKeys(int)

        public override string ToString()
        {
            String toReturn = "Interest Frequency Table";
            toReturn += "\n " + "Interest:".PadLeft(35) + " \t Number of Occurances:";
            foreach (KeyValuePair<UserInterest, int> count in this.Interests)
            {
                toReturn += "\n " + count.Key.ToString().PadLeft(35) + " \t " + count.Value;
            }
            return toReturn;
        }//end ToString()
    }
}
