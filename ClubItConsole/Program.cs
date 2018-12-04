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
            Manage Manager = new Manage();   //Nothing in the lists yet

            UserInterests testInterests = new UserInterests("i like hiking, swimming, shooting, reading books, watching netflix");
            UserInterests testInterests2 = new UserInterests("i like star trek, swimming, fishing, reading books, halo");
            UserInterests testInterests3 = new UserInterests("i like hiking, swimming, shooting, reading books, playing video games");
            UserInterests testInterests4 = new UserInterests("i like to run, jump, go to the gym, work out, be fit");
            UserInterests testInterests5 = new UserInterests("i like polish, basket weaving, bird spotting, shooting, computers");
            UserInterests testInterests6 = new UserInterests("i like polish, basket weaving, playing video games, going to the gym, computers");
            UserInterests testInterests7 = new UserInterests("i like writing, working out, playing video games, going to the gym, bird spotting");

            //testInterests.Process();
            //testInterests2.Process();
            //testInterests3.Process();
            //testInterests4.Process();
            //testInterests5.Process();
            //testInterests6.Process();
            //testInterests7.Process();

            //AllInterests DTMatrix = new AllInterests();
            //DTMatrix.AddInterests(testInterests);
            //DTMatrix.AddInterests(testInterests2);
            //DTMatrix.AddInterests(testInterests3);
            //DTMatrix.AddInterests(testInterests4);
            //DTMatrix.AddInterests(testInterests5);
            //DTMatrix.AddInterests(testInterests6);
            //DTMatrix.AddInterests(testInterests7);
            //Console.Write(DTMatrix);

            Member UserToAdd = new Member("Jacob", "hoyosj@etsu.edu", testInterests7, UserType.SuperAdmin, EventInterest.NotGoing, new Events());
            Manager.SetCurrentUser(UserToAdd);   //Basically the login
            Manager.CreateUser(UserToAdd);

            //Test Users
            Member UserToAdd1 = new Member("Rachel", "revisr@etsu.edu", testInterests, UserType.SuperAdmin, EventInterest.NotGoing, new Events());
            Member UserToAdd2 = new Member("Myra", "tdm@etsu.edu", testInterests2, UserType.ClubAdmin, EventInterest.NotGoing, new Events());
            Member UserToAdd3 = new Member("Micaela", "tuckerm@etsu.edu", testInterests3, UserType.ClubAdmin, EventInterest.NotGoing, new Events());
            Member UserToAdd4 = new Member("Mary", "snoddym@etsu.edu", testInterests4, UserType.SuperAdmin, EventInterest.NotGoing, new Events());
            Member UserToAdd5 = new Member("Brian", "bennettb@etsu.edu", testInterests5, UserType.StudentUser, EventInterest.NotGoing, new Events());
            Member UserToAdd6 = new Member("Jordan", "hoyosja@etsu.edu", testInterests6, UserType.StudentUser, EventInterest.NotGoing, new Events());

            Manager.CreateUser(UserToAdd1);
            Manager.CreateUser(UserToAdd2);
            Manager.CreateUser(UserToAdd3);
            Manager.CreateUser(UserToAdd4);
            Manager.CreateUser(UserToAdd5);
            Manager.CreateUser(UserToAdd6);

            
            Member Update = new Member("Brian", "E0090011", new UserInterests("i like russian, basket weaving, bird spotting, shooting, computers"), UserType.SuperAdmin, EventInterest.NotGoing, new Events());

            Manager.EditUser(Update, 0);

            Manager.RemoveUser(3);

            Console.Write(Manager.GetInterestFrequency());
            
            
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

            Manager.CreateClub(ClubToAdd1);
            Manager.CreateClub(ClubToAdd2);
            Manager.CreateClub(ClubToAdd3);
            Manager.CreateClub(ClubToAdd4);
            Manager.CreateClub(ClubToAdd5);
            Manager.CreateClub(ClubToAdd6);

            //Test permission access
            /*
            #region testing backend
            int iResult = 0;

            Manager.GetCurrentUser().SetUserType(UserType.StudentUser);

            iResult =  Manager.CreateEvent(Quilt, 0);
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
            Manager.GetCurrentUser().SetUserType(UserType.ClubAdmin);

            iResult = Manager.CreateEvent(Quilt, 0); //Try creating quilt again

            if (iResult == 1)
            {
                Console.WriteLine("Insufficient Permissions");
            }
            else
            {
                Console.WriteLine("Success");
            }

            Console.WriteLine(Manager.GetAllClubs().GetClubs()[0]);

            Console.WriteLine("Press Enter To Continue");
            Console.ReadLine();

            iResult = Manager.CreateEvent(MovieDay, 2);
            iResult =  Manager.CreateEvent(Gym, 5);
            iResult =  Manager.CreateEvent(Caps, 5);
            iResult =  Manager.CreateEvent(Grammer, 2);
            iResult =  Manager.CreateEvent(Vocab, 2);

            Console.WriteLine("Attempting to add an event that doesn't already exist");

            iResult =  Manager.AddEvent(2, 0);          // Grammar


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

            iResult =  Manager.AddEvent(2, 1);          // Movie
            iResult =  Manager.AddEvent(2, 2);          // Vocab

            iResult = Manager.AddEvent(2, 2);            //Try to add an additional copy

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

            Manager.GetCurrentUser().SetUserType(UserType.StudentUser);

            Event NewGrammer = new Event("Grammer Stuff", "Polish Grammar is not so hard", DateTime.Now, "Culp Center Rm 104", true, "No Image", "No URL", new Members(Grammer.GetInterest()));
            Event Quilt2 = new Event("Yarn Baskets", "We're weaving baskets for ourselves", DateTime.Now, "Culp Center Rm 301", true, "No Image", "No URL", new Members());

            #endregion

            #region Edit Event
            Console.WriteLine("Editing the Grammar Event as a student user");
            Console.WriteLine("\n\r\n\r");
            iResult = Manager.EditEvent(NewGrammer, 2, 0); //edit polish grammer

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
            Manager.GetCurrentUser().SetUserType(UserType.SuperAdmin);


            Console.WriteLine(Manager.GetAllClubs().GetClubs()[2].GetEvents());

            Console.WriteLine(Manager.GetCurrentUser());


            iResult = Manager.EditEvent(NewGrammer, 2, 0); //edit polish grammer

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
            Console.WriteLine(Manager.GetAllClubs().GetClubs()[0].GetEvents());

            Manager.EditEvent(Quilt2, 0, 0);
            //display user and club
            Console.WriteLine(Manager.GetAllClubs().GetClubs()[0].GetEvents());

            #endregion

            #region Delete Event
            Console.WriteLine("Deleting the Grammar Event as a student user");
            Console.WriteLine("\n\r\n\r");
            Manager.GetCurrentUser().SetUserType(UserType.StudentUser);
            iResult = Manager.DeleteEvent(2, 1);

            if (iResult == 1)
            {
                Console.WriteLine("Insufficient Permissions");
            }
            else
            {
                Console.WriteLine("Success");
            }
            Manager.GetCurrentUser().SetUserType(UserType.SuperAdmin);
            Console.WriteLine("Deleting an Event with members, as a club admin");
            Console.WriteLine("\n\r\n\r");
            iResult = Manager.DeleteEvent(2, 1);
            //Manager.RemoveEvent(2, 1);
            if (iResult == 1)
            {
                Console.WriteLine("Insufficient Permissions");
            }
            else
            {
                Console.WriteLine("Success");
            }

            Console.WriteLine(Manager.GetCurrentUser());
            Console.WriteLine(Manager.GetAllClubs().GetClubs()[2].GetEvents());

            Console.WriteLine("Press Enter To Continue");
            Console.ReadLine();

            Console.WriteLine("Deleting an Event with no members");
            Console.WriteLine("\n\r\n\r");
            Console.WriteLine(Manager.GetAllClubs().GetClubs()[0].GetEvents());
            Manager.DeleteEvent(0, 0);   //Delete Quilt2
            Console.WriteLine(Manager.GetAllClubs().GetClubs()[0].GetEvents());

            Console.WriteLine("Press Enter To Continue");
            Console.ReadLine();

            Manager.RemoveEvent(2, 1);

            #endregion

            #region remove event
            Console.WriteLine("Attempt to remove an item that exists");
            Console.WriteLine("\n\r\n\r");
            Console.WriteLine(Manager.GetCurrentUser());

            iResult = Manager.RemoveEvent(2, 0);

            if (iResult == 1)
            {
                Console.WriteLine("Can't remove event that doesn't exist");
            }
            else
            {
                Console.WriteLine("Success");
            }


            Console.WriteLine(Manager.GetCurrentUser());
            Console.WriteLine("Press Enter To Continue");
            Console.ReadLine();


            //remove an event that doesn't exist
            Console.WriteLine("Attempt to remove an item that doesn't exist");
            Console.WriteLine("\n\r\n\r");
            Console.WriteLine(Manager.GetCurrentUser());

            iResult = Manager.RemoveEvent(2, 1);

            if (iResult == 1)
            {
                Console.WriteLine("Can't remove event that doesn't exist");
            }
            else
            {
                Console.WriteLine("Success");
            }

            Console.WriteLine(Manager.GetCurrentUser());
            Console.WriteLine("Press Enter To Continue");
            Console.ReadLine();


            Console.Read();
            #endregion
            */

            Console.Read();
        }
    }
}
