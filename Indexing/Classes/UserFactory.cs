using Indexing.Enums;
using Indexing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexing.Classes
{
    public static class UserFactory
    {
        public static IUser GetInstance(UserTypeEnum userType)
        {
            if (userType == UserTypeEnum.Personnel)
            {
                return new Personnel();
            }

            if (userType == UserTypeEnum.Student)
            {
                return new Student();
            }

            return new Subcontractor();
        }
    }
}
