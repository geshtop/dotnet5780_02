using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Diary
    {
        public bool[,] Calender { get; set; }

        public Diary()
        {
            Calender = new bool[12, 31];
        }


        public override string ToString()
        {
            return "Diary: ...." ;
        }
    }
}
