using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GuestRequest
    {
        public DateTime Entry_Date { get; set; }
        public DateTime Release_Date { get; set; }

        public GuestRequest(DateTime _Entry_Date, DateTime _Release_Date)
        {
            Entry_Date = _Entry_Date;
            Release_Date = _Release_Date;
        }
       

        public bool Is_Approved { get; set; }
        public override string ToString()
        {
            return ("GuestRequest:\n" + Entry_Date + "\n" + Release_Date + "\n" + Is_Approved);
        }
    }
}
