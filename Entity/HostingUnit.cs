using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class HostingUnit : IComparable<HostingUnit>
    {
        private static readonly int stSerialKey = 10000000;
        public bool[,] Diary = new bool[12, 31];
        public long HostingUnitKey { get { return HostingUnitKey; } private set { HostingUnitKey = stSerialKey; } }
        
        //public Diary HostingDiary{ get; set; }

        public override string ToString()
        {
            string str = "";
            int num = 0;
            Console.WriteLine(this.HostingUnitKey);
            for (int i = 0; i < 12; i++) //Loop that passes the matrix
            {
                for (int j = 0; j < 31; j++)
                {
                    if (this.Diary[i, j] == true) //The loop stops when there is a busy day
                    {
                        num = 2;
                        str = (j + 1) + "/" + (i + 1) + " - ";
                        for (int k = i; k < 12; k++) //Internal loop that continues from the day received until there is a non-invitation day
                        {
                            for (int l = 0; l < 31; l++)
                            {
                                if (num == 2)
                                {
                                    num = 1;
                                    l = j;
                                }
                                if (this.Diary[k, l] == false || (k == 11 && l == 30)) //If we arrived for a day without a reservation or the year was over
                                {
                                    if (k == 11 && l == 30)
                                        str = +(l + 1) + "/" + (k + 1) + "\n";
                                    else
                                        str = +(l + 1) + "/" + (k + 1) + "\n";
                                    i = k;
                                    j = l;
                                    l = 31;
                                    k = 12;
                                    num = 1;
                                }
                            }
                        }
                    }
                }
            }
            return str;
            ///return "HostingUnit: " + HostingUnitKey;
        }

        public bool ApproveRequest(GuestRequest guestReq)
        {
            if (guestReq.Entry_Date.Year != guestReq.Release_Date.Year)
            {
                for (int i = guestReq.Entry_Date.Day; i < 31; i++)
                {
                    if (Diary[guestReq.Entry_Date.Month - 1, i] == true)
                    {
                        guestReq.Is_Approveed = false;
                        return false;
                    }
                }
                for (int i = guestReq.Entry_Date.Month; i < 12; i++)
                {
                    for (int j = 0; j < 31; j++)
                    {
                        if (Diary[i, j] == true)
                        {
                            guestReq.Is_Approveed = false;
                            return false;
                        }
                    }
                }
                for (int i = guestReq.Entry_Date.Day - 1; i < 31; i++)
                {
                    Diary[guestReq.Entry_Date.Month - 1, i] = true;
                }
                for (int i = guestReq.Entry_Date.Month; i < 12; i++)
                {
                    for (int j = 0; j < 31; j++)
                    {
                        Diary[i, j] = true;
                    }
                }
                guestReq.Is_Approveed = true;
                return true;
            }
            else if (guestReq.Entry_Date.Month == guestReq.Release_Date.Month)
            {
                for (int i = guestReq.Entry_Date.Day; i < guestReq.Release_Date.Day - 1; i++)
                {
                    if (Diary[guestReq.Entry_Date.Month - 1, i] == true)
                    {
                        guestReq.Is_Approveed = false;
                        return false;
                    };
                }
                for (int i = guestReq.Entry_Date.Day - 1; i < guestReq.Release_Date.Day - 1; i++)
                {
                    Diary[guestReq.Entry_Date.Month - 1, i] = true;
                }
                guestReq.Is_Approveed = true;
            }
            else
            {
                for (int i = guestReq.Entry_Date.Day; i < 31; i++)
                {
                    if (Diary[guestReq.Entry_Date.Month - 1, i] == true)
                    {
                        guestReq.Is_Approveed = false;
                        return false;
                    }
                }
                for (int i = 0; i < guestReq.Release_Date.Day - 1; i++)
                {
                    if (Diary[guestReq.Release_Date.Month - 1, i] == true)
                    {
                        guestReq.Is_Approveed = false;
                        return false;
                    }
                }
                for (int i = guestReq.Entry_Date.Month; i < guestReq.Release_Date.Month - 1; i++)
                {
                    for (int j = 0; j < 31; j++)
                    {
                        if (Diary[i, j] == true)
                        {
                            guestReq.Is_Approveed = false;
                            return false;
                        }
                    }
                }
                for (int i = guestReq.Entry_Date.Day - 1; i < 31; i++)
                {
                    Diary[guestReq.Entry_Date.Month - 1, i] = true;
                }
                for (int i = 0; i < guestReq.Release_Date.Day - 1; i++) 
                {
                    Diary[guestReq.Release_Date.Month - 1, i] = true;
                }
                for (int i = guestReq.Entry_Date.Month; i < guestReq.Release_Date.Month - 1; i++)
                {
                    for (int j = 0; j < 31; j++)
                    {
                        Diary[i, j] = true;
                    }
                }
                guestReq.Is_Approveed = true;
            }
            return true;
        }

        public int GetAnnualBusyDays()
        {
            int counter = 0;
            for (int i = 0; i < 12; i++) 
            {
                for (int j = 0; j < 31; j++)
                {
                    if (Diary[i, j] == true)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
                     
        public float GetAnnualBusyPercentage()
        {
            int counter = this.GetAnnualBusyDays();
            return (counter * 100 / (12 * 31));
        }

        int IComparable<HostingUnit>.CompareTo(HostingUnit other)
        {
            throw new NotImplementedException();
        }
    }
}
