using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HostingUnit : IComparable<HostingUnit>
    {
        private readonly int stSerialKey;
        //בנאי
        public HostingUnit()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            stSerialKey = (int)(rand.Next(1, 90000000)) + 100000000;
            HostingDiary = new Diary();
        }
        public long HostingUnitKey { get { return stSerialKey; } }

        public Diary HostingDiary { get; set; }

        public override string ToString()
        {
            return  "\n" + HostingUnitKey + "\n" + HostingDiary.ToString();
        }

        public bool ApproveRequest(GuestRequest guestReq)
        {
            return HostingDiary.ApproveRequest(guestReq);
        }

        public int GetAnnualBusyDays()
        {
            return HostingDiary.BusyDays;
        }

        public float GetAnnualBusyPercentage()
        {
            return (HostingDiary.BusyDays * 100 / (12 * 31));
        }

        public int CompareTo(HostingUnit other)
        {
            return this.HostingDiary.BusyDays.CompareTo(other.HostingDiary.BusyDays);

        }


    }
}
