using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class FirmaUrediDTO
    {

        public int iddog { get; set; }
        public string idured { get; set; }
        public string model { get; set; }
        public string name { get; set; }
        public decimal edcena { get; set; }
        public int broi { get; set; }
        public decimal total { get; set; }
        public short statusU { get; set; }
        public short status { get; set; }
        public int garancia { get; set; }
        public int profilaktika { get; set; }
    }
}
