using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HostingUnit : IComparable<HostingUnit>
    {
        private int stSerialKey;
        int HostingUnitKey
        {
            get
            {
                return stSerialKey;
            }
        }
        public  Diary HostingDiary{ get; set; }

        public override string ToString()
        {
            return "HostingUnit: " + HostingUnitKey;
        }

        public bool ApproveRequest(GuestRequest guestReq)
        {
            return false;
        }


        public int GetAnnualBusyDays()
        {
            return 0;
        }

        public float GetAnnualBusyPercentage()
        {
            return 0;
        }



        int IComparable<HostingUnit>.CompareTo(HostingUnit other)
        {
            throw new NotImplementedException();
        }
    }
}
