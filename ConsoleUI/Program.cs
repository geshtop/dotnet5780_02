﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace ConsoleUI
{
    class Program
    {
        static Random rand = new Random(DateTime.Now.Millisecond);
        private static GuestRequest CreateRandomRequest()
        {
            DateTime start = new DateTime(2019, 1, 1, 0, 0, 0);
            DateTime end = new DateTime(2019, 1, 1, 0, 0, 0);

            int range = rand.Next(1, 250);  // creates a number between 1 and 365
            int helper = range;
            start = start.AddDays(range);
            while (end < start)
            {
                range = rand.Next(1, 365);  // creates a number between 1 and 365
                end = end.AddDays(range);
            }


            GuestRequest gs = new GuestRequest(start, end);
            //Fill randomally the Entry and Release dates of gs
            return gs;
        }
        static void Main(string[] args)
        {
            List<Host> lsHosts;
            lsHosts = new List<Host>()
            {
            new Host(1, rand.Next(1,5)),
            new Host(2, rand.Next(1,5)),
            new Host(3, rand.Next(1,5)),
            new Host(4, rand.Next(1,5)),
            new Host(5, rand.Next(1,5))
            };
            for (int i = 0; i < 100; i++)
            {
                foreach (var host in lsHosts)
                {
                    GuestRequest gs1 = CreateRandomRequest();
                    GuestRequest gs2 = CreateRandomRequest();
                    GuestRequest gs3 = CreateRandomRequest();
                    switch (rand.Next(1, 4))
                    {
                        case 1:
                            host.AssignRequests(gs1);
                            break;
                        case 2:
                            host.AssignRequests(gs1, gs2);
                            break;
                        case 3:
                            host.AssignRequests(gs1, gs2, gs3);
                            break;
                        default:
                            break;
                    }
                }
            }
            //Create dictionary for all units <unitkey, occupancy_percentage>
            Dictionary<long, float> dict = new Dictionary<long, float>();
            foreach (var host in lsHosts)
            {
                //test Host IEnuramble is ok
                foreach (HostingUnit unit in host)
                {
                    dict[unit.HostingUnitKey] = unit.GetAnnualBusyPercentage();
                }
            }
            //get max value in dictionary
            float maxVal = dict.Values.Max();
            //get max value key name in dictionary
            long maxKey =
            dict.FirstOrDefault(x => x.Value == dict.Values.Max()).Key;
            //find the Host that its unit has the maximum occupancy percentage
            foreach (var host in lsHosts)
            {
                //test indexer of Host
                for (int i = 0; i < host.HostingUnitCollection.Count; i++)
                {
                    if (host[i].HostingUnitKey == maxKey)
                    {
                        //sort this host by occupancy of its units
                        host.SortUnits();
                        //print this host detailes
                        Console.WriteLine("**** Details of the Host with the most occupied unit:\n");
                        Console.WriteLine(host);
                        break;
                    }
                }
            }
        }
    }
}

