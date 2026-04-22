using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class DemDgvOlduredi
    {
        public int IdSpDm { get; set; }
        public short Faza { get; set; }
        public int IdFirmaDm { get; set; }
        public int IdKn { get; set; }
        public decimal EdCena { get; set; }
        public int Broi { get; set; }
        public short StatusDs { get; set; }
        public short Status { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }

        public virtual DemDogovor IdFirmaDmNavigation { get; set; }
    }
}
