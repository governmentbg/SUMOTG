using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Views.Spravki
{
    public class ViewSpravka6
    {
        public int idfirma { get; set; }
        public string ime { get; set; }
        public string dogovor { get; set; }
        public int iddog { get; set; }
        public string kodured { get; set; }
        public string imeured { get; set; }
        public decimal edcena { get; set; }
        public int tspbroi { get; set; }
        public decimal tsptotal { get; set; }
        public int ordbroi { get; set; }
        public int rembroi { get; set; }
        public int monbroi { get; set; }
        public decimal montotal { get; set; }
        public int restbroi { get; set; }
        public decimal resttotal { get; set; }

    }
}
