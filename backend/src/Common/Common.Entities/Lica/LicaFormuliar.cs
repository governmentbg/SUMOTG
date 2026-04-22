using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class LicaFormuliar
    {
        public LicaFormuliar()
        {
        }

        public int IdFormuliar { get; set; }
        public int IdL { get; set; }
        public string UNom { get; set; }
        public short Faza { get; set; }
        public DateTime? RegDate { get; set; }

        public int nV9 { get; set; }
        public int nV10 { get; set; }
        public short V11 { get; set; }
        public short V12 { get; set; }
        public decimal V13 { get; set; }
        public decimal V14 { get; set; }
        public decimal V15 { get; set; }
        public short V16 { get; set; }
        public short V17 { get; set; }
        public int nV18 { get; set; }
        public int nV19 { get; set; }
        public short V20 { get; set; }
        public decimal V211 { get; set; }
        public decimal V212 { get; set; }
        public decimal V213 { get; set; }
        public short V22 { get; set; }
        public short V23 { get; set; }
        public short V24 { get; set; }
        public short V25 { get; set; }
        public short V26 { get; set; }
        public short V27 { get; set; }
        public short V28 { get; set; }
        public int nV29 { get; set; }
        public short V30 { get; set; }
        public short V31 { get; set; }
        public short V32 { get; set; }
        public short V33 { get; set; }
        public short V34 { get; set; }
        public short V35 { get; set; }
        public short V36 { get; set; }
        public short V37 { get; set; }
        public short V38 { get; set; }
        public decimal V391 { get; set; }
        public decimal V392 { get; set; }
        public decimal V401 { get; set; }
        public decimal V402 { get; set; }
        public decimal V41 { get; set; }
        public decimal V421 { get; set; }
        public decimal V422 { get; set; }
        public decimal V423 { get; set; }

        public short Status { get; set; }
        public short StatusF { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }
        public int UNomer { get; set; }
        public string comentar { get; set; }

        public virtual Lica IdLNavigation { get; set; }
    }
}
