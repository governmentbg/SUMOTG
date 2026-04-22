using Common.Entities.Demontaz;
using System;
using System.Collections.Generic;


namespace Common.Entities
{
    public partial class DemPayments
    {
        public int IdRec { get; set; }
        public int IdPay { get; set; }
        public int IdFirmaDm { get; set; }
        public decimal SumaBezDds { get; set; }
        public decimal SumaSDds { get; set; }

        public virtual DemDogovor IdFirmaDmNavigation { get; set; }
    }
}
