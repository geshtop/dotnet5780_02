using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Host
    {
        public Host(int _key, int _value)
        {
            HostKey = _key;
            HostingUnitCollection = new List<HostingUnit>();
        }
        public int HostKey { get; set; }
        public List<HostingUnit> HostingUnitCollection { get; set; }

        public override string ToString()
        {
            return "Host: " + HostKey;
        }


        private long SubmitRequest(GuestRequest guestReq)
        {
            return 0;
        }

        public int GetHostAnnualBusyDays()
        {
            return 0;
        }

        public void SortUnits()
        {

        }

        public bool AssignRequests(params GuestRequest[] list)
        {
            return false;
        }
    }
}
