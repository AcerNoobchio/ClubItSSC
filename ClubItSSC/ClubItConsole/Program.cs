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

            wellok.CreateEvent(MovieDay, 2);
            wellok.CreateEvent(Quilt, 1);
            wellok.CreateEvent(Gym, 5);
            wellok.CreateEvent(Caps, 5);
            wellok.CreateEvent(Grammer, 2);
            wellok.CreateEvent(Vocab, 2);

            wellok.AddEvent(2, 0);          // Grammar
            wellok.AddEvent(2, 1);          // Movie
            wellok.AddEvent(2, 2);          // Vocab

            Event NewGrammer = new Event("Grammer Stuff", "Polish Grammar is not so hard", DateTime.Now, "Culp Center Rm 104", true, "No Image", "No URL", new Members(Grammer.GetInterest()));
            //NewGrammer.GetInterest().GetMemberList().Add(wellok.GetCurrentUser());

            // Console.WriteLine(wellok.GetAllClubs());

            Console.WriteLine(wellok.GetAllClubs().GetClubs()[2].GetEvents());
            //int iIndex = wellok.GetAllUsers().SearchMembers(wellok.GetCurrentUser());
            //Console.WriteLine(wellok.GetAllUsers().GetMemberList()[iIndex]);

            Console.WriteLine(wellok.GetCurrentUser());

            wellok.EditEvent(NewGrammer, 2, 0); //edit polish grammer
            wellok.DeleteEvent(2, 1);
            //wellok.RemoveEvent(2, 1);

            Console.WriteLine(wellok.GetCurrentUser());
            Console.WriteLine(wellok.GetAllClubs().GetClubs()[2].GetEvents());
            //iIndex = wellok.GetAllUsers().SearchMembers(wellok.GetCurrentUser());
            //Console.WriteLine(wellok.GetAllUsers().GetMemberList()[iIndex]);

            /*
            Club Update2 = new Club("Sports", "Go generic team! Fist bump! *gym bro noises*", false, new Members(wellok.GetAllUsers()), new Member(wellok.GetAllUsers().GetMemberList()[3]), new Announcements(), new Events());

            wellok.EditClub(Update2, 5);

            wellok.RemoveClub(1);

            wellok.Subscribe(1);

            for (int iCount = 0; iCount < wellok.GetAllClubs().GetClubs().Count; iCount++)
            {
                Console.WriteLine(wellok.GetAllClubs().GetClubs()[iCount]);
            }

            wellok.Unsubscribe(1);

            */
            
            Console.Read();
        }
    }
}
