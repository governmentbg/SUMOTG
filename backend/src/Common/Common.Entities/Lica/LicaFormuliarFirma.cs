using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class LicaFormuliarFirma
    {
        public int Id { get; set; }
        public int IdL { get; set; }
        public short Faza { get; set; }
        public int VidFirma { get; set; }
        public int TipFirma { get; set; }

        public string Ident { get; set; }
        public string KodKID { get; set; }
        public string Ime { get; set; }
        public string ARaion { get; set; }
        public string Nm { get; set; }
        public string Kv { get; set; }
        public string Jk { get; set; }
        public string Ul { get; set; }
        public string Nomer { get; set; }
        public string Blok { get; set; }
        public string Vh { get; set; }
        public string Etaj { get; set; }
        public string Ap { get; set; }
        public string EMail { get; set; }
        public string Tel { get; set; }
        public string Pk { get; set; }
        public short StatusL { get; set; }
        public short StatusF { get; set; }
        public short Status { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }

        public virtual Lica IdLNavigation { get; set; }
    }
}
