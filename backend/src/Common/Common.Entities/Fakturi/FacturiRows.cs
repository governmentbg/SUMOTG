using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Fakturi
{
    public class FacturiRows
    {
        public int IdRow { get; set; }
        public int IdFactura { get; set; }
        public int IdKn { get; set; }
        public string Model { get; set; }
        public decimal EdCena { get; set; }
        public int Broi { get; set; }
        public decimal Suma { get; set; }
        public short Status { get; set; }

        public virtual FacturiMain IdFacturaMainNavigation { get; set; }
    }
}
