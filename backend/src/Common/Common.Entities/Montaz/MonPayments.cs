using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class MonPayments
    {
        public int IdRec { get; set; }
        public int IdPay { get; set; }
        public int IdFirmaMn { get; set; }
        public decimal SumaBezDds { get; set; }
        public decimal SumaSDds { get; set; }

        public virtual MonDogovor IdFirmaMnNavigation { get; set; }
    }
}
