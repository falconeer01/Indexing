using Indexing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexing.Classes
{
    public class Student : IStudent
    {
        public short studentId { get; set; }
        public byte absentDays { get; set; }
        public byte grade { get; set; }
        public byte id { get; set; }
        public bool isLoggedIn { get; set; }
        public bool isActive { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public Student() { }

        public Student(
                    short _studentId,
                    byte _absentDays,
                    byte _grade,
                    byte _id,
                    bool _isLoggedIn,
                    bool _isActive,
                    string _firstName,
                    string _lastName,
                    string _userName,
                    string _password
               )
        {
            studentId = _studentId;
            absentDays = _absentDays;
            grade = _grade;
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
