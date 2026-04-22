using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public partial class LicaFormuliarKolektiv
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdL { get; set; }
        public int VIdent { get; set; }
        public string Ident { get; set; }
        public string Ime { get; set; }
        public string NLk { get; set; }
        public DateTime? DataIzdavane { get; set; }
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
        public string Zona { get; set; }
        public string V7 { get; set; }
        public int nV8 { get; set; }

        public short StatusL { get; set; }
        public short Status { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }
        public short IsTitulqr { get; set; }
        public int TypeLice { get; set; }

        public virtual Lica IdLNavigation { get; set; }
    }
}
