using Indexing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexing.Classes
{
    public class User : IUser
    {
        public byte id { get; set; }
        public bool isLoggedIn { get; set; }
        public bool isActive { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public User() { }

        public User(byte _id, bool _isLoggedIn, bool _isActive, string _firstName, string _lastName, string _userName, string _password)
        {
            id = _id;
            isLoggedIn = _isLoggedIn;
            isActive = _isActive;
            firstName = _firstName;
            lastName = _lastName;
            userName = _userName;
            password = _password;
        }
    }
}
