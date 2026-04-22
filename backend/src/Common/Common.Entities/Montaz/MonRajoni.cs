using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class MonRajoni
    {
        public int IdRec { get; set; }
        public short? Faza { get; set; }
        public int? IdFirmaMn { get; set; }
        public string Nkod { get; set; }
        public short Status { get; set; }

        public virtual MonDogovor IdFirmaMnNavigation { get; set; }
    }
}
