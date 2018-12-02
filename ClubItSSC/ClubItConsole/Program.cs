using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClubItSSC;


namespace ClubItSSCConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Manage wellok = new Manage();   //Nothing in the lists yet
            UserInterest testinterest = new UserInterest("I Like Hiking and swimming and fishing and I hate to go to the mountains");

            NLPUtil.RemoveStopWords(testinterest);
            NLPUtil.RemovePrepositions(testinterest);
            NLPUtil.Stem(testinterest);

            Console.Write(testinterest);

            UserInterests testInterests = new UserInterests("i like hiking, swimming, shooting, reading books, watching tv and other stuff");
            testInterests.Process();
            Console.Write(testInterests);

            Member UserToAdd = new Member("Jacob", "hoyosj@etsu.edu", new UserInterests(), UserType.SuperAdmin, EventInterest.NotGoing, new Events());
            wellok.SetCurrentUser(UserToAdd);   //Basically the login
            wellok.CreateUser(UserToAdd);

            //Test Users
            Member UserToAdd1 = new Member("Rachel", "revisr@etsu.edu", new UserInterests(), UserType.SuperAdmin, EventInterest.NotGoing, new Events());
            Member UserToAdd2 = new Member("Myra", "tdm@etsu.edu", new UserInterests(), UserType.ClubAdmin, EventInterest.NotGoing, new Events());
            Member UserToAdd3 = new Member("Micaela", "tuckerm@etsu.edu", new UserInterests(), UserType.ClubAdmin, EventInterest.NotGoing, new Events());
            Member UserToAdd4 = new Member("Mary", "snoddym@etsu.edu", new UserInterests(), UserType.SuperAdmin, EventInterest.NotGoing, new Events());
            Member UserToAdd5 = new Member("Brian", "bennettb@etsu.edu", new UserInterests(), UserType.StudentUser, EventInterest.NotGoing, new Events());

            wellok.CreateUser(UserToAdd1);
            wellok.CreateUser(UserToAdd2);
            wellok.CreateUser(UserToAdd3);
            wellok.CreateUser(UserToAdd4);
            wellok.CreateUser(UserToAdd5);

            /*
            Member Update = new Member("Brian", "E0090011", new UserInterests(), UserType.SuperAdmin, EventInterest.NotGoing, new Events());

            wellok.EditUser(Update, 5);

            wellok.RemoveUser(2);
           

            for (int iCount = 0; iCount < wellok.GetAllUsers().GetMemberList().Count; iCount++)
            {
                Console.WriteLine(wellok.GetAllUsers().GetMemberList()[iCount]);
            }
            */
            //Test Events, simulate typed in fields in the gui 

            Event MovieDay = new Event("MovieDay", "We're watching a polish movie", DateTime.Now, "Culp Center Rm 104", true, "No Image", "No URL", new Members());
            Event Quilt = new Event("Yarn Baskets", "We're weaving baskets for the quilt club", DateTime.Now, "Culp Center Rm 301", true, "No Image", "No URL", new Members());
            Event Gym = new Event("GYYYYM", "BRING YOUR PROTEAN SHAKES WERE GETTIN SWOLLLLLL", DateTime.Now, "CPA", true, "No Image", "No URL", new Members());
            Event Caps = new Event("Caps Lock Debate", "The last event brought up concerns about proper typing", DateTime.Now, "Gilbreath Lobby", true, "No Image", "No URL", new Members());
            Event Grammer = new Event("Grammer Help Me", "Polish Grammar is hard", DateTime.Now, "Culp Center Rm 104", true, "No Image", "No URL", new Members());
            Event Vocab = new Event("Vocab Building", "Come to build some Polish Vocab!", DateTime.Now, "Culp Center Rm 104", true, "No Image", "No URL", new Members());

            //Test Clubs

            Club ClubToAdd1 = new Club("Hiking", "We just hike lol", false, new Members(), new Member(), new Announcements(), new Events());
            Club ClubToAdd2 = new Club("Basket Weaving", "We weave because nobody else will", false, new Members(), new Member(), new Announcements(), new Events());
            Club ClubToAdd3 = new Club("Polish", "Witamy na stronie klubu", false, new Members(), new Member(), new Announcements(), new Events());
            Club ClubToAdd4 = new Club("Reading", "Shhhhhh!", false, new Members(), new Member(), new Announcements(), new Events());
            Club ClubToAdd5 = new Club("Swimming", "Don't drown", false, new Members(), new Member(), new Announcements(), new Events());
            Club ClubToAdd6 = new Club("Sports", "Go generic team! Fist bump! *gym bro noises*", false, new Members(), new Member(), new Announcements(), new Events());

            wellok.CreateClub(ClubToAdd1);
            wellok.CreateClub(ClubToAdd2);
            wellok.CreateClub(ClubToAdd3);
            wellok.CreateClub(ClubToAdd4);
            wellok.CreateClub(ClubToAdd5);
            wellok.CreateClub(ClubToAdd6);

            //Test permission access
            /*
            #region testing backend
            int iResult = 0;

            wellok.GetCurrentUser().SetUserType(UserType.StudentUser);

            iResult =  wellok.CreateEvent(Quilt, 0);
            Console.WriteLine("Attempting to create an event as a student user");
            if (iResult == 1)
            {
                Console.WriteLine("Insufficient Permissions");
            }
            else
            {
                Console.WriteLine("Success");
            }

            Console.WriteLine("Attempting to add an event that doesn't already exist");
            wellok.GetCurrentUser().SetUserType(UserType.ClubAdmin);

            iResult = wellok.CreateEvent(Quilt, 0); //Try creating quilt again

            if (iResult == 1)
            {
                Console.WriteLine("Insufficient Permissions");
            }
            else
            {
                Console.WriteLine("Success");
            }

            Console.WriteLine(wellok.GetAllClubs().GetClubs()[0]);

            Console.WriteLine("Press Enter To Continue");
            Console.ReadLine();

            iResult = wellok.CreateEvent(MovieDay, 2);
            iResult =  wellok.CreateEvent(Gym, 5);
            iResult =  wellok.CreateEvent(Caps, 5);
            iResult =  wellok.CreateEvent(Grammer, 2);
            iResult =  wellok.CreateEvent(Vocab, 2);

            Console.WriteLine("Attempting to add an event that doesn't already exist");

            iResult =  wellok.AddEvent(2, 0);          // Grammar


            if (iResult == 1)
            {
                Console.WriteLine("Insufficient Permissions");
            }
            else
            {
                Console.WriteLine("Success");
            }

            Console.WriteLine("Press Enter To Continue");
            Console.ReadLine();

            iResult =  wellok.AddEvent(2, 1);          // Movie
            iResult =  wellok.AddEvent(2, 2);          // Vocab

            iResult = wellok.AddEvent(2, 2);            //Try to add an additional copy

            Console.WriteLine("Attempting to add a duplicate event");
            if (iResult == 1)
            {
                Console.WriteLine("Addition Failed");
            }
            else
            {
                Console.WriteLine("Success");
            }

            Console.WriteLine("Press Enter To Continue");
            Console.ReadLine();

            wellok.GetCurrentUser().SetUserType(UserType.StudentUser);

            Event NewGrammer = new Event("Grammer Stuff", "Polish Grammar is not so hard", DateTime.Now, "Culp Center Rm 104", true, "No Image", "No URL", new Members(Grammer.GetInterest()));
            Event Quilt2 = new Event("Yarn Baskets", "We're weaving baskets for ourselves", DateTime.Now, "Culp Center Rm 301", true, "No Image", "No URL", new Members());

            #endregion

            #region Edit Event
            Console.WriteLine("Editing the Grammar Event as a student user");
            Console.WriteLine("\n\r\n\r");
            iResult = wellok.EditEvent(NewGrammer, 2, 0); //edit polish grammer

            if (iResult == 1)
            {
                Console.WriteLine("Insufficient Permissions");
            }
            else
            {
                Console.WriteLine("Success");
            }

            Console.WriteLine("Press Enter To Continue");
            Console.ReadLine();
            Console.WriteLine("Editing the Grammar Event as a Super admin");
            Console.WriteLine("\n\r\n\r");
            wellok.GetCurrentUser().SetUserType(UserType.SuperAdmin);


            Console.WriteLine(wellok.GetAllClubs().GetClubs()[2].GetEvents());

            Console.WriteLine(wellok.GetCurrentUser());


            iResult = wellok.EditEvent(NewGrammer, 2, 0); //edit polish grammer

            if (iResult == 1)
            {
                Console.WriteLine("Insufficient Permissions");
            }
            else
            {
                Console.WriteLine("Success");
            }

            Console.WriteLine("Press Enter To Continue");
            Console.ReadLine();

            Console.WriteLine("Editing an Event with no users");
            Console.WriteLine("\n\r\n\r");
            Console.WriteLine(wellok.GetAllClubs().GetClubs()[0].GetEvents());

            wellok.EditEvent(Quilt2, 0, 0);
            //display user and club
            Console.WriteLine(wellok.GetAllClubs().GetClubs()[0].GetEvents());

            #endregion

            #region Delete Event
            Console.WriteLine("Deleting the Grammar Event as a student user");
            Console.WriteLine("\n\r\n\r");
            wellok.GetCurrentUser().SetUserType(UserType.StudentUser);
            iResult = wellok.DeleteEvent(2, 1);

            if (iResult == 1)
            {
                Console.WriteLine("Insufficient Permissions");
            }
            else
            {
                Console.WriteLine("Success");
            }
            wellok.GetCurrentUser().SetUserType(UserType.SuperAdmin);
            Console.WriteLine("Deleting an Event with members, as a club admin");
            Console.WriteLine("\n\r\n\r");
            iResult = wellok.DeleteEvent(2, 1);
            //wellok.RemoveEvent(2, 1);
            if (iResult == 1)
            {
                Console.WriteLine("Insufficient Permissions");
            }
            else
            {
                Console.WriteLine("Success");
            }

            Console.WriteLine(wellok.GetCurrentUser());
            Console.WriteLine(wellok.GetAllClubs().GetClubs()[2].GetEvents());

            Console.WriteLine("Press Enter To Continue");
            Console.ReadLine();

            Console.WriteLine("Deleting an Event with no members");
            Console.WriteLine("\n\r\n\r");
            Console.WriteLine(wellok.GetAllClubs().GetClubs()[0].GetEvents());
            wellok.DeleteEvent(0, 0);   //Delete Quilt2
            Console.WriteLine(wellok.GetAllClubs().GetClubs()[0].GetEvents());

            Console.WriteLine("Press Enter To Continue");
            Console.ReadLine();

            wellok.RemoveEvent(2, 1);

            #endregion

            #region remove event
            Console.WriteLine("Attempt to remove an item that exists");
            Console.WriteLine("\n\r\n\r");
            Console.WriteLine(wellok.GetCurrentUser());

            iResult = wellok.RemoveEvent(2, 0);

            if (iResult == 1)
            {
                Console.WriteLine("Can't remove event that doesn't exist");
            }
            else
            {
                Console.WriteLine("Success");
            }


            Console.WriteLine(wellok.GetCurrentUser());
            Console.WriteLine("Press Enter To Continue");
            Console.ReadLine();


            //remove an event that doesn't exist
            Console.WriteLine("Attempt to remove an item that doesn't exist");
            Console.WriteLine("\n\r\n\r");
            Console.WriteLine(wellok.GetCurrentUser());

            iResult = wellok.RemoveEvent(2, 1);

            if (iResult == 1)
            {
                Console.WriteLine("Can't remove event that doesn't exist");
            }
            else
            {
                Console.WriteLine("Success");
            }

            Console.WriteLine(wellok.GetCurrentUser());
            Console.WriteLine("Press Enter To Continue");
            Console.ReadLine();


            Console.Read();
            #endregion
            */

            Console.Read();
        }
    }
}
