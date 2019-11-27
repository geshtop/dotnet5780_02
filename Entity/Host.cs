using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Host : IEnumerable<HostingUnit> //Host class
    {
        public Host(int _key, int _numOfHostings) //constructor
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

        public override string ToString() //Print the host's hosting units
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

        public int GetHostAnnualBusyDays() //Checks busy days in all units
        {
            int counter = 0;
            for (int i = 0; i < HostingUnitCollection.Count(); i++)
            {
                counter += HostingUnitCollection[i].GetAnnualBusyDays();
            }

            return counter;
        }

        public void SortUnits()  //Sorting units by occupancy
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

        public HostingUnit this[int index] //Returns a unit serial number
        {
            get
            {
                if (index < HostingUnitCollection.Count())
                {
                    return HostingUnitCollection[index];
                }
                return null;
            }
           // set { /* set the specified index to value here */ }
        }
        
        public IEnumerator<HostingUnit> GetEnumerator() 
        {
            foreach (HostingUnit val in HostingUnitCollection)
            {
                yield return val;
            }
        }
        
        //This method is also needed, but usually you don't need to change it from this.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
