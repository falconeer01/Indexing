using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexing.Interfaces
{
    public interface IStudent : IUser
    {
        short studentId { get; set; }
        byte absentDays { get; set; }
        byte grade { get; set; }
    }
}
