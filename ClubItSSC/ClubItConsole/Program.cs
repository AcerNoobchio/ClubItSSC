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

            Member UserToAdd = new Member("Jacob", "Eblahblah", new UserInterests(), UserType.SuperAdmin, EventInterest.NotGoing, new Events());
            wellok.SetCurrentUser(UserToAdd);   //Basically the login
            wellok.CreateUser(UserToAdd);

            //Test Users
            Member UserToAdd1 = new Member("Rachel", "Eblahblah", new UserInterests(), UserType.SuperAdmin, EventInterest.NotGoing, new Events());
            Member UserToAdd2 = new Member("Myra", "Eblahblah", new UserInterests(), UserType.ClubAdmin, EventInterest.NotGoing, new Events());
            Member UserToAdd3 = new Member("Micaela", "Eblahblah", new UserInterests(), UserType.ClubAdmin, EventInterest.NotGoing, new Events());
            Member UserToAdd4 = new Member("Mary", "Eblahblah", new UserInterests(), UserType.SuperAdmin, EventInterest.NotGoing, new Events());
            Member UserToAdd5 = new Member("Brian", "Eblahblah", new UserInterests(), UserType.StudentUser, EventInterest.NotGoing, new Events());

            wellok.CreateUser(UserToAdd1);
            wellok.CreateUser(UserToAdd2);
            wellok.CreateUser(UserToAdd3);
            wellok.CreateUser(UserToAdd4);
            wellok.CreateUser(UserToAdd5);

            Member Update = new Member("Brian", "E0090011", new UserInterests(), UserType.SuperAdmin, EventInterest.NotGoing, new Events());

            wellok.EditUser(Update, 5);

            wellok.RemoveUser(2);

            for (int iCount = 0; iCount < wellok.GetAllUsers().GetMemberList().Count; iCount++)
            {
                Console.WriteLine(wellok.GetAllUsers().GetMemberList()[iCount]);
            }

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

            Club Update2 = new Club("Sports", "Go generic team! Fist bump! *gym bro noises*", false, new Members(wellok.GetAllUsers()), new Member(wellok.GetAllUsers().GetMemberList()[3]), new Announcements(), new Events());

            wellok.EditClub(Update2, 5);

            wellok.RemoveClub(1);

            wellok.Subscribe(1);

            for (int iCount = 0; iCount < wellok.GetAllClubs().GetClubs().Count; iCount++)
            {
                Console.WriteLine(wellok.GetAllClubs().GetClubs()[iCount]);
            }

            wellok.Unsubscribe(1);

            Console.Read();
        }
    }
}
