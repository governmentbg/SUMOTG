using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Views
{
    public class ViewFakturaItems
    {
        public int idfaktura { get; set; }
        public int idured { get; set; }
        public decimal edcena { get; set; }
        public int broi { get; set; }
        public decimal total { get; set; }
        public short status { get; set; }
    }
}
