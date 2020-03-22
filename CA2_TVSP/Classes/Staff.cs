using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_TVSP.Classes
{
    public class Staff : Member
    {
        public Staff(String pFirstName, String pLastName, DateTime pDateTime, String pRole) 
            : base(pFirstName, pLastName, pDateTime, pRole) {}

    }
}
