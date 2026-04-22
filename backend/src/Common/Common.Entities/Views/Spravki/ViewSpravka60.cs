using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Views.Spravki
{
    public class ViewSpravka60
    {
        public string raion { get; set; }
        public string unom { get; set; }
        public string ured { get; set; }
        public string ime { get; set; }
        public string adres { get; set; }
        public int period { get; set; }
        public int pnomer { get; set; }
        public DateTime? data { get; set; }
        public DateTime? otchdata { get; set; }
        public string status { get; set; }
        public int idporychka { get; set; }
        public string note { get; set; }
        public string dogfirma { get; set; }
        public string namefirma { get; set; }

    }
}
