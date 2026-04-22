using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Views
{
    public class ViewOrder
    {
        public int idporychkamain { get; set; }
        public int nomer { get; set; }
        public DateTime? data { get; set; }
        public int idfirma { get; set; }
        public int iddogovorfirma { get; set; }
        public string raion { get; set; }
        public int faza { get; set; }
        public List<ViewMonOrderItem> porychkaitems { get; set; }
        public short status { get; set; }
        public DateTime? startData { get; set; }
        public DateTime? endData { get; set; }
        public short status_pm { get; set; }
        public string note { get; set; }
        public int idmonporychka { get; set; }

    }
}
