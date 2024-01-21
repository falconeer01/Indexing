using Indexing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexing.Classes
{
    public class Personnel : IPersonnel
    {
        public byte id { get; set; }
        public bool isLoggedIn { get; set; }
        public bool isActive { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string recordNumber { get; set; }
        public short dailySalary { get; set; }
        public short workedDays { get; set; }

        public Personnel() { }

        public Personnel
            (
                byte _id,
                bool _isActive, 
                bool _isLoggedIn, 
                string _firstName,
                string _lastName,
                string _userName,
                string _password,
                string _recordNumber,
                short _dailySalary,
                short _workedDays
            )
        {
            id = _id;
            isActive = _isActive;
            isLoggedIn = _isLoggedIn;
            firstName = _firstName;
            lastName = _lastName;
            userName = _userName;
            password = _password;
            recordNumber = _recordNumber;
            dailySalary = _dailySalary;
            workedDays = _workedDays;
        }

        public void netSalary(short dailySalary, short workedDays)
        {
            short netSalary = ((short)(dailySalary * workedDays));
            Console.WriteLine($"Net salary is {netSalary}");
        }
    }
}
