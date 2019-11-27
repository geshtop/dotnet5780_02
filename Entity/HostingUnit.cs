using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HostingUnit : IComparable<HostingUnit> //Hosting Unit Class
    {
        private static int stSerialKey = 10000000;
        private int hostingKey { get; set; }
        public HostingUnit() //constructor
        {
            hostingKey = stSerialKey++;
            HostingDiary = new Diary();
        }
        public long HostingUnitKey { get { return this.hostingKey; } } //Unit number

        public Diary HostingDiary { get; set; }

        public override string ToString()  //Print the unit number and busy days
        {
            return  "\n" + HostingUnitKey + "\n" + HostingDiary.ToString();
        }

        public bool ApproveRequest(GuestRequest guestReq)
        {
            return HostingDiary.ApproveRequest(guestReq);
        }

        public int GetAnnualBusyDays() //The amount of orange days per unit
        {
            return HostingDiary.BusyDays;
        }

        public float GetAnnualBusyPercentage() //Percentage of occupied days per hosting unit
        {
            return (HostingDiary.BusyDays * 100 / (12 * 31));
        }

        public int CompareTo(HostingUnit other) //Comparing units by number of days
        {
            return this.HostingDiary.BusyDays.CompareTo(other.HostingDiary.BusyDays);

        }
    }
}
