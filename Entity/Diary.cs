// rivki kanterovich 212030761
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Diary
    {
        //לוח השנה
        public bool[,] Calender { get; set; }
        //מספר הימים המלאים
        public int BusyDays { get; set; }
        //התקופות המלאות
        public List<GuestRequest> ApprovedTimes { get; set; }

        public Diary()
        {
            Calender = new bool[12, 31];
            ApprovedTimes = new List<GuestRequest>();
            BusyDays = 0;
        }


        public bool ApproveRequest(GuestRequest guestReq)
        {
           return SetCalendarDatesAsBusy(guestReq);
        }
        //קבלת הימים המלאים בלוח השנה
        //public int sdsBusyDays()
        //{
        //    int counter = 0;
        //    for (int i = 0; i < 12; i++)
        //    {
        //        for (int j = 0; j < 31; j++)
        //        {
        //            if (Calender[i, j] == true)
        //            {
        //                counter++;
        //            }
        //        }
        //    }
        //    return counter;
        //}

        //פונקציה הבודקת האם הימים הם ימים חופשיים
        private bool CheckForFreeDays(GuestRequest guestReq)
        {

            bool flag = true;
            //בדיקה אם המדובר על חציית שנה
            if (guestReq.Entry_Date.Year != guestReq.Release_Date.Year)
            {
                //מעדכנים את התאריך לסוף השנה 
                guestReq.Release_Date = new DateTime(guestReq.Entry_Date.Year, 12, 31);
            }
            //אם המדובר על אותו החודש באותה השנה
            if (guestReq.Entry_Date.Month == guestReq.Release_Date.Month)
            {
                for (int i = guestReq.Entry_Date.Day; i < guestReq.Release_Date.Day - 1; i++)
                {
                    if (Calender[guestReq.Entry_Date.Month - 1, i] == true)
                    {
                        flag = false;
                        continue;
                    };
                }
            }
            //אותה שנה חודשים שונים
            else
            {
                //בדיקת החודש החודש הראשון
                for (int i = guestReq.Entry_Date.Day; i < 31; i++)
                {
                    if (Calender[guestReq.Entry_Date.Month - 1, i] == true)
                    {
                        flag = false;
                        continue;
                    }
                }
                //בדיקת החודש האחרון
                if (flag)
                {
                    for (int i = 0; i < guestReq.Release_Date.Day - 1; i++)
                    {
                        if (Calender[guestReq.Release_Date.Month - 1, i] == true)
                        {
                            flag = false;
                            continue;
                        }
                    }
                }
                //בדיקת החודשים בין הראשון לאחרון
                if (flag)
                {
                    for (int i = guestReq.Entry_Date.Month; i < guestReq.Release_Date.Month - 1; i++)
                    {
                        for (int j = 0; j < 31; j++)
                        {
                            if (Calender[i, j] == true)
                            {
                                flag = false;
                                continue;
                            }
                        }
                    }
                }
               
            }
            return flag;
        }

        //פונקציה שמסמנת את הימים כתפוסים
        private bool SetCalendarDatesAsBusy(GuestRequest guestReq)
        {
            bool flag = CheckForFreeDays(guestReq);
            if (flag)
            {
                guestReq.Is_Approved = true;
                ApprovedTimes.Add(guestReq);

                //אם המדובר על אותו החודש באותה השנה
                if (guestReq.Entry_Date.Month == guestReq.Release_Date.Month)
                {
                    for (int i = guestReq.Entry_Date.Day - 1; i < guestReq.Release_Date.Day - 1; i++)
                    {
                        BusyDays++;
                        Calender[guestReq.Entry_Date.Month - 1, i] = true;
                    }
                }
                //אותה שנה חודשים שונים
                else
                {
                    //מילוי החודש החודש הראשון
                    for (int i = guestReq.Entry_Date.Day - 1; i < 31; i++)
                    {
                        BusyDays++;
                        Calender[guestReq.Entry_Date.Month - 1, i] = true;
                    }

                    //מילוי החודש האחרון
                    for (int i = 0; i < guestReq.Release_Date.Day - 1; i++)
                    {
                        BusyDays++;
                        Calender[guestReq.Release_Date.Month - 1, i] = true;
                    }
                    //מילוי החודשים בין הראשון לאחרון
                    for (int i = guestReq.Entry_Date.Month; i < guestReq.Release_Date.Month - 1; i++)
                    {
                        for (int j = 0; j < 31; j++)
                        {
                            BusyDays++;
                            Calender[i, j] = true;
                        }
                    }
                }
            }
            return flag;
        }


        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < ApprovedTimes.Count(); i++)
            {
                s += ApprovedTimes[i].Entry_Date.ToString("dd/MM/yyyy") + " - " + ApprovedTimes[i].Release_Date.ToString("dd/MM/yyyy") + "\n";
            }
            return s;
        }
        //public override string ToString(string format)
        //{
        //    string s = "";
        //    switch (format)
        //    {
        //        case "T":
        //            for (int i = 0; i < ApprovedTimes.Count(); i++)
        //            {
        //                s += ApprovedTimes[i].Entry_Date.ToString("dd/MM/yyyy") + " - " + ApprovedTimes[i].Entry_Date.ToString("dd/MM/yyyy") + "\n";
        //            }
        //            break;

        //        default:
        //            break;
        //    }
        //    return s;
        //}
    }
}
