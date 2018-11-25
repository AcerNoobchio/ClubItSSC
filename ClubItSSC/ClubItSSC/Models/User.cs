using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ClubItSSC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User() { }
        public User(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }

        public bool CheckInformation()
        {
            if(!this.Email.Equals("") && !this.Password.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
