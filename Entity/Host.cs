using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Host
    {
        public Host(int _key, int _numOfHostings)
        {
            HostKey = _key;
            HostingUnitCollection = new List<HostingUnit>();
            for (int i = 0; i < _numOfHostings; i++)
            {
                HostingUnitCollection.Add(new HostingUnit());
            }
        }
        public int HostKey { get; set; }
        public List<HostingUnit> HostingUnitCollection { get; set; }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < HostingUnitCollection.Count(); i++)
            {
                s += HostingUnitCollection[i].ToString();
                s += "------------------------------";
            }

            return s;
        }


        private long SubmitRequest(GuestRequest guestReq)
        {
            return 0;
        }

        public int GetHostAnnualBusyDays()
        {
            int counter = 0;
            for (int i = 0; i < HostingUnitCollection.Count(); i++)
            {
                counter += HostingUnitCollection[i].GetAnnualBusyDays();
            }

            return counter;
        }

        public void SortUnits()
        {
            HostingUnitCollection.Sort();
        }

        public bool AssignRequests(params GuestRequest[] list)
        {
            bool success = true;
            for (int i = 0; i < list.Length; i++)
            {
                for (int j = 0; j < HostingUnitCollection.Count(); j++)
                {
                    if (!list[i].Is_Approved)
                    {
                        HostingUnitCollection[j].ApproveRequest(list[i]);
                    }
                }
                if(!list[i].Is_Approved) success = false;
            }
            return success;
        }
    }
}
