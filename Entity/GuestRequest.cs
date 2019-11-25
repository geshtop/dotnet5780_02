using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GuestRequest
    {
        public DateTime Entry_Date { get { return Entry_Date; } set { Entry_Date = value; } }
        public DateTime Release_Date { get { return Release_Date; } set { Release_Date = value; } }
        public bool Is_Approveed { get { return Is_Approveed; } set { Is_Approveed = value; } }

        public override string ToString()
        {
            return ("GuestRequest:\n" + Entry_Date + "\n" + Release_Date + "\n" + Is_Approveed);
        }
    }
}
