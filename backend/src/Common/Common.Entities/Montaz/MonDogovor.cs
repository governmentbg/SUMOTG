using Common.Entities.Montaz;
using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class MonDogovor
    {
        public MonDogovor()
        {
            MonDgvUredis = new HashSet<MonDgvUredi>();
            MonPorychkaMain = new HashSet<MonPorychkaMain>();
            MonRajonis = new HashSet<MonRajoni>();
            MonPayments = new HashSet<MonPayments>();
        }

        public int IdFirmaMn { get; set; }
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
        public virtual ICollection<MonDgvUredi> MonDgvUredis { get; set; }
        public virtual ICollection<MonPorychkaMain> MonPorychkaMain { get; set; }
        public virtual ICollection<MonRajoni> MonRajonis { get; set; }
        public virtual ICollection<MonPayments> MonPayments { get; set; }
    }
}
