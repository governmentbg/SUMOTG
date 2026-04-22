using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class DemRajoni
    {
        public int IdRec { get; set; }
        public short? Faza { get; set; }
        public int? IdFirmaDm { get; set; }
        public string Nkod { get; set; }
        public short Status { get; set; }

        public virtual DemDogovor IdFirmaDmNavigation { get; set; }
    }
}
