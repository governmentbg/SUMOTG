using Common.Entities.Fakturi;
using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class Firmi
    {
        public Firmi()
        {
            FirmiDogovorMontzj = new HashSet<MonDogovor>();
            FirmiDogovorDeMontzj = new HashSet<DemDogovor>();
            FirmiFacturiMain = new HashSet<FacturiMain>();
        }

        public int IdFirma { get; set; }
        public short Faza { get; set; }
        public int Rolq { get; set; }
        public string EIK { get; set; }
        public string Ime { get; set; }
        public string nkid { get; set; }
        public string Adres { get; set; }
        public string EMail { get; set; }
        public string Tel { get; set; }
        public string Pk { get; set; }
        public string Manager { get; set; }
        public string MName { get; set; }
        public short StatusDm { get; set; }
        public short Status { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }

        public virtual ICollection<MonDogovor> FirmiDogovorMontzj { get; set; }
        public virtual ICollection<DemDogovor> FirmiDogovorDeMontzj { get; set; }
        public virtual ICollection<FacturiMain> FirmiFacturiMain { get; set; }
        
    }
}
