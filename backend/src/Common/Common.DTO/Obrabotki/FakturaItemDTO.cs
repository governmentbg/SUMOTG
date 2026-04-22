using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class FakturaItemDTO
    {
        public int idfactura { get; set; }
        public string id { get; set; }
        public decimal edcena { get; set; }
        public int broi { get; set; }
        public decimal total { get; set; }
        public short status { get; set; }
    }
}
