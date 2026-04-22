using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Fakturi
{
    public class FacturiDokumenti
    {
        public int IdDok { get; set; }
        public int IdFactura { get; set; }
        public int DocType { get; set; }
        public string DocDescription { get; set; }
        public string FileName { get; set; }
        public string SavedFileName { get; set; }
        public short Status { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }

        public virtual FacturiMain IdFacturaMainNavigation { get; set; }
    }
}
