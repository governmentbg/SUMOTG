using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Fakturi
{
    public class FacturiMain
    {
        public FacturiMain()
        {
            FacturiRowsSet = new HashSet<FacturiRows>();
        }

        public int IdFactura { get; set; }
        public int VidFirma { get; set; }
        public int IdFirma { get; set; }
        public string FacNomer { get; set; }
        public DateTime? FacData { get; set; }
        public int idDogovorFirma { get; set; }
        public decimal Suma { get; set; }
        public decimal DDS { get; set; }
        public decimal Total { get; set; }
        public short BroiFiles { get; set; }
        public short Status { get; set; }
        public string VidPayment { get; set; }
        public string ForPeriod { get; set; }

        public virtual Firmi IdFirmaNavigation { get; set; }
        public virtual ICollection<FacturiRows> FacturiRowsSet { get; set; }
        public virtual ICollection<FacturiDokumenti> FacturiDocsSet { get; set; }

    }
}
