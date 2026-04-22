using Common.Entities.Demontaz;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public partial class DemPorychka
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPorachkaBody { get; set; }
        public int IdPorachkaMain { get; set; }
        public int IdDogovorLice { get; set; }
        public int IdUred { get; set; }
        public int Broi { get; set; }
        public DateTime? DoData { get; set; }
        public string OtChas { get; set; }
        public string DoChas { get; set; }
        public string Note { get; set; }

        public DateTime? DemData { get; set; }

        public short StatusG { get; set; }
        public short StatusM { get; set; }
        public short Status { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }
        public int IdFactura { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Snimka { get; set; }
        public string Note2 { get; set; }

        public virtual LicaDogovor IdLiceDogovorNavigation { get; set; }
        public virtual DemPorychkaMain IdMainNavigation { get; set; }
    }
}
