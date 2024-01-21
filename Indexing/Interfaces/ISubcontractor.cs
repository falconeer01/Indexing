using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexing.Interfaces
{
    public interface ISubcontractor : IUser
    {
        string plate { get; set; }
        string workArea { get; set; }
    }
}
