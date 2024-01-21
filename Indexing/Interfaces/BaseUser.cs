using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexing.Interfaces
{
    public interface IUser
    {
        byte id { get; set; }
        bool isLoggedIn { get; set; }
        bool isActive { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string userName { get; set; }
        string password { get; set; }
    }
}
