using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GuestRequest
    {
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsApproved { get; set; }

        public override string ToString()
        {
            return "GuestRequest: " + EntryDate + " " + ReleaseDate;
        }

    }
}
