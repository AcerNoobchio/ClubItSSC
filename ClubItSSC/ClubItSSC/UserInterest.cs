using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    class UserInterest
    {
        private String Name;
        private String Description;

        #region Constructors
        public UserInterest()
        {
            Name = "Not Entered";
            Description = "Not Entered";
        }//end UserInterest()

        public UserInterest(String NameIn, String DescriptionIn)
        {
            Name = NameIn;
            Description = DescriptionIn;
        }//end UserInterest(String, String)

        public UserInterest(UserInterest InterestIn)
        {
            this.Name = InterestIn.Name;
            this.Description = InterestIn.Description;
        }//end UserInterest(UserInterest)
        #endregion

        #region Setters and Getters
        public void SetName(String NameIn)
        {
            this.Name = NameIn;
        }

        public String GetName()
        {
            return this.Name;
        }

        public void SetDescription(String DescriptionIn)
        {
            this.Description = DescriptionIn;
        }

        public String GetDescription()
        {
            return this.Description;
        }
        #endregion
    }//end UserInterest
}
