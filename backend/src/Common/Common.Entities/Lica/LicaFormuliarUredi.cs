using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class LicaFormuliarUredi
    {
        public int IdUredF { get; set; }
        public int IdFormuliar { get; set; }
        public int IdL { get; set; }
        public int IdKt { get; set; }
        public int Broi { get; set; }
        public short StatusU { get; set; }
        public short Status { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }

        public virtual Lica IdLNavigation { get; set; }
    }
}
