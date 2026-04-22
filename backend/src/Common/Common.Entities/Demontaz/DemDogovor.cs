using Common.Entities.Demontaz;
using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class DemDogovor
    {
        public DemDogovor()
        {
            DemDgvOlduredis = new HashSet<DemDgvOlduredi>();
            DemPorychkaMain = new HashSet<DemPorychkaMain>();
            DemRajonis = new HashSet<DemRajoni>();
            DemPayments = new HashSet<DemPayments>();
        }

        public int IdFirmaDm { get; set; }
        public short Faza { get; set; }
        public int IdFirma { get; set; }
        public string RegIndex { get; set; }
        public DateTime? DataRegN { get; set; }
        public int NomDgVSudso { get; set; }
        public DateTime? NachalnaData { get; set; }
        public int ObshtSrokGrf { get; set; }
        public decimal ObshtaCenaBezDds { get; set; }
        public decimal ObshtaCenaSDds { get; set; }
        public short StatusDm { get; set; }
        public short Status { get; set; }
        public DateTime? Koga { get; set; }
        public string User { get; set; }

        public virtual Firmi IdFirmaNavigation { get; set; }

        public virtual ICollection<DemDgvOlduredi> DemDgvOlduredis { get; set; }
        public virtual ICollection<DemPorychkaMain> DemPorychkaMain { get; set; }
        public virtual ICollection<DemRajoni> DemRajonis { get; set; }
        public virtual ICollection<DemPayments> DemPayments { get; set; }
    }
}
