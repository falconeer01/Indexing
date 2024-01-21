using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexing.Interfaces
{
    public interface IPersonnel : IUser
    {
        string recordNumber { get; set; }
        short dailySalary { get; set; }
        short workedDays { get; set; }
        void netSalary(short dailySalary, short workedDays);
    }
}
